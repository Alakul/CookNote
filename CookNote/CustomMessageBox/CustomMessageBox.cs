using System;
using System.Windows;
using System.Windows.Media;

namespace CookNote.CustomMessageBox
{
    public sealed class CustomMessageBox
    {
        public static void Show(string message, string messageSmall, string title)
        {
            using (MessageBoxWindow msg = new MessageBoxWindow())
            {
                msg.Title = title;
                msg.TxtTitle.Text = title;
                msg.TxtMessage.Text = message;
                msg.TxtSmallMessage.Text = messageSmall;
                msg.BtnCancel.Visibility = Visibility.Collapsed;
                msg.BtnOk.Content = "OK";
                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }
        public static void ShowNoWarning(string message, string messageSmall, string title)
        {
            using (MessageBoxWindow msg = new MessageBoxWindow())
            {
                msg.Title = title;
                msg.TxtTitle.Text = title;
                msg.TxtMessage.Text = message;
                msg.TxtSmallMessage.Text = messageSmall;
                msg.Icon.Visibility = Visibility.Collapsed;
                msg.BtnCancel.Visibility = Visibility.Collapsed;
                msg.BtnOk.Content = "OK";
                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }
        public static MessageBoxResult ShowWithCancel(string message, string messageSmall, string title)
        {
            try
            {
                using (MessageBoxWindow msg = new MessageBoxWindow())
                {
                    msg.Title = title;
                    msg.TxtTitle.Text = title;
                    msg.TxtMessage.Text = message;
                    msg.TxtSmallMessage.Text = messageSmall;
                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }
    }
}
