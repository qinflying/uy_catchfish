using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    //武器数组，威力从小到大
    public GameObject[] m_GunArrays;
    public Text m_GunCostLabel;
    //当前威力索引
    private int _currentPowerIndex = 0;
    //最大威力索引
    private int _currentMaxPowerIndex = -1;//-1为未设置
    //当前武器索引
    private int _gunIndex = 0;

    public int currentMaxPowerIndex
    {
        get
        {
            if (_currentMaxPowerIndex == -1)
            {
                int level = 0;
                foreach (GameObject gun in m_GunArrays)
                {
                    level += gun.GetComponent<GunAttr>().powerLevel;
                }
                _currentMaxPowerIndex = level;
            }
            return _currentMaxPowerIndex;
        }
    }
    //当前威力等级
    public int currentPowerLv
    {
        get
        {
            return _currentPowerIndex + 1;
        }
    }
    //当前武器等级
    public int currentGunLv
    {
        get
        {
            return _gunIndex + 1;
        }
    }

    //当前消耗
    public int currentCost
    {
        get
        {
            if (currentGun)
            {
                return currentGun.GetComponent<GunAttr>().GetCurrentCost();
            }
            return 0;
        }
    }

    //当前枪
    public GameObject currentGun
    {
        get
        {
            if (_gunIndex >= 0 && _gunIndex < m_GunArrays.Length)
            {
                return m_GunArrays[_gunIndex];
            }
            return null;
        }
    }

    void Update() {
        OnMouseScrollChangePower();
    }

    //鼠标滚轮切换火力
    private void OnMouseScrollChangePower() {
        float fH = Input.GetAxis("Mouse ScrollWheel");
        if (fH > 0) {
            OnUpgradeGun();
        }
        else if (fH < 0) {
            OnMinusGun();
        }
    }

    //武器提升
    public void OnUpgradeGun()
    {
        if (currentGun)
        {
            GunAttr oGunAttr = currentGun.GetComponent<GunAttr>();
            bool bUpgrade = oGunAttr.AddPower();
            //当前枪切升级威力成功
            if (bUpgrade)
            {
                _currentPowerIndex++;
            }
            else
            {
                //当前枪已经是最大威力，换枪
                _gunIndex++;
                if (_gunIndex >= m_GunArrays.Length)
                {
                    _gunIndex = 0;
                    _currentPowerIndex = 0;
                }
                else
                {
                    _currentPowerIndex++;
                }
                currentGun.GetComponent<GunAttr>().initMinPower();
                switchGun();
            }
            swithGunCost();
        }
    }

    //武器降级
    public void OnMinusGun()
    {
        if (currentGun)
        {
            GunAttr oGunAttr = currentGun.GetComponent<GunAttr>();
            bool bMinus = oGunAttr.MinusPower();
            if (bMinus)
            {
                _currentPowerIndex--;
            }
            else
            {
                _gunIndex--;
                if (_gunIndex < 0)
                {
                    _gunIndex = m_GunArrays.Length - 1;
                    if (currentMaxPowerIndex > 0)
                    {
                        _currentPowerIndex = currentMaxPowerIndex - 1;
                    }
                    else
                    {
                        _currentPowerIndex = 0;
                    }

                }
                else
                {
                    _currentPowerIndex--;
                }
                currentGun.GetComponent<GunAttr>().initMaxPower();
                switchGun();
            }
            swithGunCost();
        }
    }

    private void switchGun() {
        foreach (GameObject gun in m_GunArrays) {
            gun.SetActive(gun == currentGun);
        }
    }

    private void swithGunCost() {
        if (currentGun) {
            m_GunCostLabel.text = "$" + currentGun.GetComponent<GunAttr>().GetCurrentCost();
        }
    }
}
