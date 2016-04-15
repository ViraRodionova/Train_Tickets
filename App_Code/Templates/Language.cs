using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Language
/// </summary>

public abstract class State
{
    public string state;

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
    public abstract string Cart_Congradulations();
    public abstract string Login_Failed();
    //public abstract string Login_LoginBtn();
    public abstract string PersPage_TableHeader();
    public abstract string Reg_NameLbl();
    public abstract string Reg_SurnameLbl();
    public abstract string Reg_PasswordLbl();
    public abstract string Reg_ConfirmPassLbl();
    public abstract string Reg_CompareValidator();
    public abstract string Reg_Phone();
    public abstract string Reg_RegBtn();
    public abstract string CarrView_CarrName();
    public abstract string CarrView_ToCartBtn();
    public abstract string Home_SearchBtn();
    public abstract string SearchRes_NoTrains();
    public abstract string Master_Login();
    public abstract string Master_LogOut();
    public abstract string Master_Greeting();
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

    public override string Login_Failed()
    {
        return "Авторизація провалилася";
    }

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

    public override string Reg_CompareValidator()
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
        return "Прізвище:";
    }

    public override string SearchRes_NoTrains()
    {
        return "За даним маршрутом не знайдено потягів";
    }

    public override string Master_Greeting()
    {
        return "Вітаємо Вас, ";
    }

    public override string Cart_Congradulations()
    {
        return "Вітаємо з покупкою!";
    }
}

public class EnglishLang : State
{
    public override string[] Builder_CarriageTypes()
    {
        return new string[] { "Reserved", "Coupe", "Lux" };
    }

    public override string Builder_ChooseBtn()
    {
        return "Choose";
    }

    public override string Builder_ShowFullRouteLbtn()
    {
        return "Show full route";
    }

    public override string CarrView_CarrName()
    {
        return "Carriage";
    }

    public override string CarrView_ToCartBtn()
    {
        return "Add to cart";
    }

    public override string Cart_CancelBtn()
    {
        return "Cancel";
    }

    public override string Cart_OkBtn()
    {
        return "Buy";
    }

    public override string Cart_TableHeader()
    {
        return string.Format(@"<h3>Your order</h3>
                                    <tr>
                                        <td width = '50px'>Train</td>
                                        <td width = '50px'>Carriage</td>
                                        <td width = '50px'>Place</td>
                                    </tr>");
    }

    public override string ConnClass_RegisterUserOk()
    {
        return "User is registrated!";
    }

    public override string ConnClass_RegisterUserFail()
    {
        return "User with the same email has been already registrated!";
    }

    public override string Handler_LoginError()
    {
        return "You didn't login. Go to \"Login\" page";
    }

    public override string Handler_NoClientOrders()
    {
        return "Your cart is empty";
    }

    public override string Handler_NoOrdersInDB()
    {
        return "Your hasn't bought any tickets on our site";
    }

    public override string Home_SearchBtn()
    {
        return "Search";
    }

    public override string Login_Failed()
    {
        return "Login failed";
    }

    //public override string Login_LoginBtn()
    //{
    //    return "Увійти";
    //}

    public override string Master_Cart()
    {
        return "Cart";
    }

    public override string Master_ClientOrders()
    {
        return "My Orders";
    }

    public override string Master_Home()
    {
        return "Home";
    }

    public override string Master_Login()
    {
        return "Login";
    }

    public override string Master_LogOut()
    {
        return "Logout";
    }

    public override string PersPage_TableHeader()
    {
        return string.Format(@"<h3>Your orders</h3>
                                    <tr>
                                        <td width = '150px'>Train</td>
                                        <td width = '150px'>Carriage</td>
                                        <td width = '150px'>Place</td>
                                        <td width = '200px'>Price</td>
                                        <td width = '250px'>Date of buying</td>
                                    </tr><hr>");
    }

    public override string Reg_ConfirmPassLbl()
    {
        return "Confirm the password:";
    }

    public override string Reg_CompareValidator()
    {
        return "Passwords don't match";
    }

    public override string Reg_NameLbl()
    {
        return "Name:";
    }

    public override string Reg_PasswordLbl()
    {
        return "Password:";
    }

    public override string Reg_Phone()
    {
        return "Phone:";
    }

    public override string Reg_RegBtn()
    {
        return "Register";
    }

    public override string Reg_SurnameLbl()
    {
        return "Surname:";
    }

    public override string SearchRes_NoTrains()
    {
        return "On this route no trains found";
    }

    public override string Master_Greeting()
    {
        return "Welcome, ";
    }

    public override string Cart_Congradulations()
    {
        return "Congratulations on your needs";
    }
}

public static class Language
{
    static State language;
    static string lang;

    static Language()
    {
        language = new UkrainianLang();
    }

    public static State GetLang()
    {
        return language;
    }

    public static string GetState()
    {
        return lang;
    }

    public static void ChangeLanguage(string _lang)
    {
        switch (_lang)
        {
            case "eng":
                language = new EnglishLang();
                lang = _lang;
                break;
            default:
                language = new UkrainianLang();
                lang = "ukr";
                break;
        }
    }
}