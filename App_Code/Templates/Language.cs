using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Language
/// </summary>

public abstract class State
{
    protected string state;

    public abstract string ConnClass_RegisterUserOk();
    public abstract string ConnClass_RegisterUserFail();
    public abstract string Builder_ShowFullRouteLbtn();
    public abstract string Builder_ChooseBtn();
    public abstract string[] Builder_CarriageTypes();
    public abstract string Handler_LoginError();
    public abstract string Handler_NoClientOrders();
    public abstract string Handler_NoOrdersInDB();
    public abstract string Cart_TableHeader();
    public abstract string Cart_OkBtn();
    public abstract string Cart_CancelBtn();
    //public abstract string Login_Failed();
    //public abstract string Login_LoginBtn();
    public abstract string PersPage_TableHeader();
    public abstract string Reg_NameLbl();
    public abstract string Reg_SurnameLbl();
    public abstract string Reg_PasswordLbl();
    public abstract string Reg_ConfirmPassLbl();
    public abstract string Reg_ConfirmValidator();
    public abstract string Reg_Phone();
    public abstract string Reg_RegBtn();
    public abstract string CarrView_CarrName();
    public abstract string CarrView_ToCartBtn();
    public abstract string Home_SearchBtn();
    public abstract string SearchRes_NoTrains();
    public abstract string Master_Login();
    public abstract string Master_LogOut();
    public abstract string Master_Home();
    public abstract string Master_Cart();
    public abstract string Master_ClientOrders();
}

public class UkrainianLang : State
{
    public override string[] Builder_CarriageTypes()
    {
        return new string[] { "Плацкарт", "Купе", "Люкс" };
    }

    public override string Builder_ChooseBtn()
    {
        return "Вибрати";
    }

    public override string Builder_ShowFullRouteLbtn()
    {
        return "Показати повний шлях";
    }

    public override string CarrView_CarrName()
    {
        return "Вагон";
    }

    public override string CarrView_ToCartBtn()
    {
        return "Додати у кошик";
    }

    public override string Cart_CancelBtn()
    {
        return "Відміна";
    }

    public override string Cart_OkBtn()
    {
        return "Купити";
    }

    public override string Cart_TableHeader()
    {
        return string.Format(@"<h3>Ваше замовлення</h3>
                                    <tr>
                                        <td width = '50px'>Поїзд</td>
                                        <td width = '50px'>Вагон</td>
                                        <td width = '50px'>Місце</td>
                                    </tr>");
    }

    public override string ConnClass_RegisterUserOk()
    {
        return "Користувача зареєстровано!";
    }

    public override string ConnClass_RegisterUserFail()
    {
        return "Користувач з такою електронною поштою вже був зареєстрований на сайті";
    }

    public override string Handler_LoginError()
    {
        return "Ви не авторизувалися на сайті. Перейдіть на сторінку \"Увійти\" й увійдіть на сайт";
    }

    public override string Handler_NoClientOrders()
    {
        return "Ваш кошик порожній";
    }

    public override string Handler_NoOrdersInDB()
    {
        return "У Вас ще не було замовлень на нашому сайті";
    }

    public override string Home_SearchBtn()
    {
        return "Пошук";
    }

    //public override string Login_Failed()
    //{
    //    throw new NotImplementedException();
    //}

    //public override string Login_LoginBtn()
    //{
    //    return "Увійти";
    //}

    public override string Master_Cart()
    {
        return "Кошик";
    }

    public override string Master_ClientOrders()
    {
        return "Мої замовлення";
    }

    public override string Master_Home()
    {
        return "На головну";
    }

    public override string Master_Login()
    {
        return "Увійти";
    }

    public override string Master_LogOut()
    {
        return "Вийти";
    }

    public override string PersPage_TableHeader()
    {
        return string.Format(@"<h3>Ваші замовлення</h3>
                                    <tr>
                                        <td width = '150px'>Поїзд</td>
                                        <td width = '150px'>Вагон</td>
                                        <td width = '150px'>Місце</td>
                                        <td width = '200px'>Ціна</td>
                                        <td width = '250px'>Дата покупки</td>
                                    </tr><hr>");
    }

    public override string Reg_ConfirmPassLbl()
    {
        return "Повторіть пароль:";
    }

    public override string Reg_ConfirmValidator()
    {
        return "Паролі не співпадають";
    }

    public override string Reg_NameLbl()
    {
        return "Ім'я:";
    }

    public override string Reg_PasswordLbl()
    {
        return "Пароль:";
    }

    public override string Reg_Phone()
    {
        return "Телефон:";
    }

    public override string Reg_RegBtn()
    {
        return "Зареєструватися";
    }

    public override string Reg_SurnameLbl()
    {
        return "Прізвище";
    }

    public override string SearchRes_NoTrains()
    {
        return "За даним маршрутом не знайдено потягів";
    }
}

public class EnglishLang : State
{
    public override string[] Builder_CarriageTypes()
    {
        throw new NotImplementedException();
    }

    public override string Builder_ChooseBtn()
    {
        throw new NotImplementedException();
    }

    public override string Builder_ShowFullRouteLbtn()
    {
        throw new NotImplementedException();
    }

    public override string CarrView_CarrName()
    {
        throw new NotImplementedException();
    }

    public override string CarrView_ToCartBtn()
    {
        throw new NotImplementedException();
    }

    public override string Cart_CancelBtn()
    {
        throw new NotImplementedException();
    }

    public override string Cart_OkBtn()
    {
        throw new NotImplementedException();
    }

    public override string Cart_TableHeader()
    {
        throw new NotImplementedException();
    }

    public override string ConnClass_RegisterUserFail()
    {
        throw new NotImplementedException();
    }

    public override string ConnClass_RegisterUserOk()
    {
        throw new NotImplementedException();
    }

    public override string Handler_LoginError()
    {
        throw new NotImplementedException();
    }

    public override string Handler_NoClientOrders()
    {
        throw new NotImplementedException();
    }

    public override string Handler_NoOrdersInDB()
    {
        throw new NotImplementedException();
    }

    public override string Home_SearchBtn()
    {
        return "Search";
    }

    public override string Master_Cart()
    {
        throw new NotImplementedException();
    }

    public override string Master_ClientOrders()
    {
        throw new NotImplementedException();
    }

    public override string Master_Home()
    {
        throw new NotImplementedException();
    }

    public override string Master_Login()
    {
        throw new NotImplementedException();
    }

    public override string Master_LogOut()
    {
        throw new NotImplementedException();
    }

    public override string PersPage_TableHeader()
    {
        throw new NotImplementedException();
    }

    public override string Reg_ConfirmPassLbl()
    {
        throw new NotImplementedException();
    }

    public override string Reg_ConfirmValidator()
    {
        throw new NotImplementedException();
    }

    public override string Reg_NameLbl()
    {
        throw new NotImplementedException();
    }

    public override string Reg_PasswordLbl()
    {
        throw new NotImplementedException();
    }

    public override string Reg_Phone()
    {
        throw new NotImplementedException();
    }

    public override string Reg_RegBtn()
    {
        throw new NotImplementedException();
    }

    public override string Reg_SurnameLbl()
    {
        throw new NotImplementedException();
    }

    public override string SearchRes_NoTrains()
    {
        throw new NotImplementedException();
    }
}

public static class Language
{
    static State language;

    static Language()
    {
        language = new UkrainianLang();
    }

    public static State GetLang()
    {
        return language;
    }

    public static void ChangeLanguage(string lang)
    {
        switch (lang)
        {
            case "eng":
                language = new EnglishLang();
                break;
            default:
                language = new UkrainianLang();
                break;
        }
    }
}