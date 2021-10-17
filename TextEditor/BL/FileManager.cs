using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextEditor.BL
{
    /// <summary>
    /// Интерфейс класса FileManager
    /// </summary>
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string content, string filePath, Encoding encoding);
        void SaveContent(string content, string filePath);
        bool IsExist(string filePath);
    }
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Дефолтная кодировка
        /// </summary>
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        #region Получение контента
        /// <summary>
        /// Получение контента с кодировокой
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }
        /// <summary>
        /// Получение  контента без кодировки
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }
        #endregion

        #region Сохранение  контента
        /// <summary>
        /// Сохранение контента с кодировкой
        /// </summary>
        /// <param name="content"></param>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }
        /// <summary>
        /// Сохранение контента без кодировки
        /// </summary>
        /// <param name="content"></param>
        /// <param name="filePath"></param>
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        #endregion

        /// <summary>
        /// Проверка существует ли фаил
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }
    }
}
