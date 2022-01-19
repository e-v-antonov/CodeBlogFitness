using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Базовый класс для методов
    /// </summary>
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new SerializeDataSaver();

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);
        }

        /// <summary>
        /// Загрузить данные. 
        /// </summary>
        protected T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }
    }
}
