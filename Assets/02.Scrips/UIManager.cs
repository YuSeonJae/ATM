using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;
    [SerializeField] TMP_Text balanceTxt;

    [SerializeField] TMP_InputField inputValue;
    [SerializeField] TMP_InputField outputValue;

    [SerializeField] GameObject popupError;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    string FormatNumber(int num)
    {
        return string.Format("{0:N0}", num);
    }
    void Refresh()
    {
        cashTxt.text = FormatNumber(MoneyManager.instance.userData.cash);
        balanceTxt.text = FormatNumber(MoneyManager.instance.userData.balance);
    }

    public void Deposit(int money)
    {
        // ������ ���ݺ��� ���� ���� ���� ���� ����.
        if(money > MoneyManager.instance.userData.cash)
        {
            popupError.SetActive(true);
            return;
        }

        //�Ա� ����
        MoneyManager.instance.userData.cash -= money;
        MoneyManager.instance.userData.balance += money;

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (money > MoneyManager.instance.userData.balance)
        {
            popupError.SetActive(true);
            return;
        }

        //��� ����
        MoneyManager.instance.userData.balance -= money;
        MoneyManager.instance.userData.cash += money;

        Refresh();
    }

    public void CustomDeposit()
    {
        Deposit(int.Parse(inputValue.text));
    }
    public void CustomWithdraw()
    {
        Withdraw(int.Parse(outputValue.text));
    }
}
