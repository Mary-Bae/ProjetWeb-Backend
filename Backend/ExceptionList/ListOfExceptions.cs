﻿namespace ExceptionList
{
        public enum ErreurCodeEnum
        {
            UserExists,
            LoginFailed,
            LoginOrPasswordFailed,
            InvalidToken,
            UserNotFound,
            RoleNotFound,
            CourseNotFound
    }
        public class ListOfExceptions : Exception
        {
            int _codeError;

            public ListOfExceptions(ErreurCodeEnum pCodeError) : base(SetBaseMessage(pCodeError))
            {
                _codeError = (int)pCodeError;
            }
            public ListOfExceptions(ErreurCodeEnum pCodeError, Exception inner) : base(SetBaseMessage(pCodeError), inner)
            {
                _codeError = (int)pCodeError;
            }
            public int CodeError
            { get { return _codeError; } }

            private static string SetBaseMessage(ErreurCodeEnum pCodeError)
            {
                string _messageToReturn;

                switch (pCodeError)
                {
                    case ErreurCodeEnum.UserExists:
                        _messageToReturn = "L'utilisateur existe déjà ";
                        break;
                    case ErreurCodeEnum.LoginFailed:
                        _messageToReturn = "Login non valide ";
                        break;
                    case ErreurCodeEnum.LoginOrPasswordFailed:
                        _messageToReturn = "Login ou mot de passe non valide ";
                    break;
                case ErreurCodeEnum.InvalidToken:
                    _messageToReturn = "Token non valide ";
                    break;
                case ErreurCodeEnum.UserNotFound:
                    _messageToReturn = "Utilisateur introuvable ";
                    break;
                case ErreurCodeEnum.RoleNotFound:
                    _messageToReturn = "Role introuvable ";
                    break;
                case ErreurCodeEnum.CourseNotFound:
                    _messageToReturn = "Cours introuvable ";
                    break;
                default:
                        _messageToReturn = "Erreur non reconnue";
                    break;
                }
                return _messageToReturn;
            }
        }
}