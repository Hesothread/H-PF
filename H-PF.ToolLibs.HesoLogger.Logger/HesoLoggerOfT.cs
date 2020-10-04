using H_PF.ToolLibs.HesoLogger.Domaine.Models;
using System;
using System.Runtime.CompilerServices;

namespace H_PF.ToolLibs.HesoLogger.Domaine
{
    public interface IHesoLogger<T> : IHesoLogger
    {

    }
    public class HesoLogger<ParentClass> : IHesoLogger<ParentClass>
    {

        private readonly IHesoLogger _logger;

        /// <summary>
        /// Creates a new <see cref="Logger{T}"/>.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public HesoLogger(IHesoLogger logger)
        {
            _logger = logger;
            _logger.SetModule(typeof(ParentClass));
        }

        public void Error(HesoLogError logError)
        {
            _logger.Error(logError);
        }

        public void Error(string message, [CallerMemberName] string title = "", Exception ex = null, ELogLevel level = ELogLevel.Level1)
        {
            _logger.Error(message, title, ex, level);
        }

        public void ErrorAdvanced(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.ErrorAdvanced(message, title, ex);
        }

        public void ErrorDisplayed(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.ErrorDisplayed(message, title, ex);
        }

        public void ErrorHidden(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.ErrorHidden(message, title, ex);
        }

        public void Information(HesoLogInformation logInfo)
        {
            _logger.Information(logInfo);
        }

        public void Information(string message, [CallerMemberName] string title = "", ELogLevel level = ELogLevel.Level1)
        {
            _logger.Information(message, title, level);
        }

        public void InformationAdvanced(string message, [CallerMemberName] string title = "")
        {
            _logger.InformationAdvanced(message, title);
        }

        public void InformationDisplayed(string message, [CallerMemberName] string title = "")
        {
            _logger.InformationDisplayed(message, title);
        }

        public void InformationHidden(string message, [CallerMemberName] string title = "")
        {
            _logger.InformationHidden(message, title);
        }

        public void Warning(HesoLogWarning logWarning)
        {
            _logger.Warning(logWarning);
        }

        public void Warning(string message, [CallerMemberName] string title = "", Exception ex = null, ELogLevel level = ELogLevel.Level1)
        {
            _logger.Warning(message, title, ex, level);
        }

        public void WarningAdvanced(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.WarningAdvanced(message, title, ex);
        }

        public void WarningDisplayed(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.WarningDisplayed(message, title, ex);
        }

        public void WarningHidden(string message, [CallerMemberName] string title = "", Exception ex = null)
        {
            _logger.WarningHidden(message, title, ex);
        }
    }
}
