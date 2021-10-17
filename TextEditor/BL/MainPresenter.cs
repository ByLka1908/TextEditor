using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.BL
{
    class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IFileManager _manager;
        private readonly IMessageService _message;
        private string _currentFilePath;
        public MainPresenter(IMainForm view , IFileManager manager, IMessageService message)
        {
            _view = view;
            _manager = manager;
            _message = message;

            _view.ContentChanged += new EventHandler(_view_ContentChanged);
            _view.FileOpenClick += new EventHandler(_view_FileOpenClick);
            _view.FileSaveClick += new EventHandler(_view_FileSaveClick);
        }

        /// <summary>
        /// Событие сохранения файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;
                _manager.SaveContent(content, _currentFilePath);
                _message.ShowMessage("Файл успешно сохранен.");
            }
            catch(Exception ex)
            {
                _message.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// Событые открытия файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                bool isExist = _manager.IsExist(filePath);
                if (!isExist)
                {
                    _message.ShowExclamation("Выбранный файл не существует.");
                    return;
                }
                _currentFilePath = filePath;

                string content = _manager.GetContent(filePath);
                _view.Content = content;
            }
            catch(Exception ex)
            {
                _message.ShowError(ex.Message);
            }
        }
        /// <summary>
        /// Контент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _view_ContentChanged(object sender, EventArgs e)
        {
            string content = _view.Content;      
        }
    }
}
