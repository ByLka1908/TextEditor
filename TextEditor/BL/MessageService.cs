using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.BL
{
    /// <summary>
    /// Интерфейс класса MessageService
    /// </summary>
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
    }
    /// <summary>
    /// Вывод сообщений 
    /// </summary>
    class MessageService : IMessageService
    {
        /// <summary>
        /// Обычные сообщения
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Предупреждения
        /// </summary>
        /// <param name="exclamation"></param>
        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        /// <summary>
        /// Ошибки
        /// </summary>
        /// <param name="error"></param>
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
