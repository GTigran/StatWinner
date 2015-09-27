using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.Common.Responses
{
    public enum ResponseStatuses { NotSet = -3, Success = 0, PartialSuccess = -2, Failure = -1, Unknown = 1 }
    public interface IResponse<T>
    {
        T Result { get; set; }
    }
    public interface IListResponse<T>
    {
        List<T> Result { get; set; }
    }
    public interface IError
    {
        List<Error> ToErrorList();
    }

    public class Error
    {
        #region Constants

        private const string DefaultErrorMessage = "Error has occured while performing operation. Please contact support to resolve this issue.";

        #endregion

        #region Constructors

        public Error() { }

        public Error(Exception ex)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
        }

        #endregion

        #region Private fields

        private string _stackTrace;

        #endregion

        #region Properties

        public string StackTrace { get; set; }

        public string IDField { get; set; }

        public string Message
        {
            get; set;
        }


        #endregion
    }

    public class ErrorCollection : List<Error>
    {
        #region Events and Delegates

        public event EventHandler<Error> ErrorAdded;

        protected void OnErrorAdded(Error error)
        {
            if (ErrorAdded != null)
            {
                ErrorAdded(this, error);
            }
        }

        #endregion

        public new void Add(Error error)
        {
            if (error != null)
            {
                base.Add(error);
                OnErrorAdded(error);
            }
        }

        public new void AddRange(IEnumerable<Error> errors)
        {
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    this.Add(error);
                }
            }
        }
    }

    public class BaseResponse
    {
        private readonly ErrorCollection _errors;
        public ErrorCollection Errors
        {
            get { return _errors; }
            set { }
        }
        public string PreviewBaseURL { get; set; }
        public int RetryCount { get; set; }
        public bool HasError { get { return _errors != null && _errors.Count > 0; } }
        public ResponseStatuses ResponseStatus { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        #region .ctor

        public BaseResponse()
        {
            HttpStatusCode = System.Net.HttpStatusCode.OK;
            this._errors = new ErrorCollection();
            this._errors.ErrorAdded += OnErrorAdded;
        }

        #endregion

        #region Public methods

        public void SetWarning(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                this.ResponseStatus = ResponseStatuses.PartialSuccess;
                Errors.Add(new Error { Message = message });
            }
        }

        public void SetError(string errorMessage, HttpStatusCode code)
        {
            SetError(errorMessage, null, code);
        }

        public void SetError(string errorMessage)
        {
            if (!String.IsNullOrWhiteSpace(errorMessage))
            {
                SetError(errorMessage, null, HttpStatusCode.InternalServerError);
            }
        }

        public void SetError(Exception ex)
        {
            if (ex != null)
            {
                SetError(ex.ToString(), ex.StackTrace, HttpStatusCode.InternalServerError);
            }
        }

        public void SetErrors(ErrorCollection errors)
        {
            this._errors.AddRange(errors);
        }

        public static T CreateFailureResponse<T>(string errorMessage) where T : BaseResponse, new()
        {
            var response = new T();
            response.HttpStatusCode = HttpStatusCode.InternalServerError;
            response.SetError(errorMessage);
            return response;
        }

        public static T CreateFailureResponse<T>(string errorMessage, ref T response) where T : BaseResponse, new()
        {
            if (response == null)
                response = new T();
            response.SetError(errorMessage);
            return response;
        }

        public static T CreateResponse<T>(BaseResponse response) where T : BaseResponse, new()
        {
            var returnValue = new T();
            if (response != null)
            {
                returnValue.Errors.AddRange(response.Errors);
                returnValue.HttpStatusCode = response.HttpStatusCode;
                returnValue.ResponseStatus = response.ResponseStatus;
                returnValue.RetryCount = response.RetryCount;
                returnValue.PreviewBaseURL = response.PreviewBaseURL;
            }

            return returnValue;
        }

        #endregion

        #region Private methods

        private void SetError(string errorMessage, string stackTrace, HttpStatusCode httpStatusCode)
        {
            this.Errors.Add(new Error { Message = errorMessage, StackTrace = stackTrace });
            this.ResponseStatus = ResponseStatuses.Failure;
            this.HttpStatusCode = httpStatusCode;
        }

        private void OnErrorAdded(object sender, Error e)
        {
            if (e != null)
            {
                this.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
        }

        #endregion
    }

    public class ListResponse<T> : BaseResponse, IListResponse<T>
    {
        public ListResponse()
        {
            Result = new List<T>();
            TotalCount = 0;
            PageIndex = 0;
            PageSize = 0;
        }

        public List<T> Result { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public ListResponse<TTarget> Map<TTarget>(Func<T, TTarget> function)
        {
            if (function != null)
            {
                var newResponse = new ListResponse<TTarget>
                {
                    PageSize = this.PageSize,
                    ResponseStatus = this.ResponseStatus,
                    PageIndex = this.PageIndex,
                    TotalCount = this.TotalCount,
                    Result = Result.Select(function).ToList()
                };
                newResponse.SetErrors(this.Errors);

                return newResponse;
            }

            return null;
        }
    }

    public class GroupResponse
    {
        /// <summary>
        /// Group ID (string so that it is flexible for int/guid/string IDs etc.)
        /// </summary>
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public int? GroupCount { get; set; }
    }

    public class ObjectResponse<T> : BaseResponse, IResponse<T>
    {
        public T Result { get; set; }

        public ObjectResponse<TTarget> Map<TTarget>(Func<T, TTarget> function)
        {
            if (function != null)
            {
                var newResponse = new ObjectResponse<TTarget>
                {
                    ResponseStatus = this.ResponseStatus,
                    Result = function(this.Result)
                };

                newResponse.SetErrors(this.Errors);

                return newResponse;
            }

            return null;
        }
    }

    public class GroupObjectResponse<T> : ObjectResponse<T>
    {
        public List<GroupResponse> Groups { get; set; }
        public List<FilterResponse> Filters { get; set; }
        public GroupObjectResponse()
        {
            Groups = new List<GroupResponse>();
            Filters = new List<FilterResponse>();

        }
    }

    public class FilterResponse
    {
        public string Name { get; set; }
        public List<FilterValue> Values { get; set; }
    }

    public class FilterValue
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public bool IsSelected { get; set; }
    }

    public class FileResponse : BaseResponse, IResponse<byte[]>
    {
        public byte[] Result { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
    }

    public class Int32Response : BaseResponse, IResponse<int>
    {
        public int Result { get; set; }
    }

    public class BooleanResponse : BaseResponse, IResponse<bool>
    {
        public bool Result { get; set; }
        public BooleanResponse()
        {
            Result = false;
        }
    }

    public class StringResponse : BaseResponse, IResponse<string>
    {
        public string Result { get; set; }
    }

}
