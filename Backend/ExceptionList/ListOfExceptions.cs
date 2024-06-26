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
            CourseNotFound,
            GradeExists,
            GradeNotFound,
            UnrollExists,
            UnrollNotFound,
            InstructorOnly,
            CourseExists,
            StudentsUnrolled,
            TeacherInCourse
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
                case ErreurCodeEnum.GradeExists:
                    _messageToReturn = "L'étudiant possède déjà un grade ";
                    break;
                case ErreurCodeEnum.GradeNotFound:
                    _messageToReturn = "L'étudiant ne possède pas de grade à modifier ";
                    break;
                case ErreurCodeEnum.UnrollExists:
                    _messageToReturn = "L'étudiant est déjà enrollé à ce cours ";
                    break;
                case ErreurCodeEnum.UnrollNotFound:
                    _messageToReturn = "L'étudiant n'est pas enrollé à ce cours ";
                    break;
                case ErreurCodeEnum.InstructorOnly:
                    _messageToReturn = "Seuls les instructeurs peuvent donner cours.";
                    break;
                case ErreurCodeEnum.CourseExists:
                    _messageToReturn = "Un cours au même nom et au même niveau existe déjà.";
                    break;
                case ErreurCodeEnum.StudentsUnrolled:
                    _messageToReturn = "Des etudiants sont encore inscrits à ce cours, désenrollez ces étudiants avant de le supprimer.";
                    break;
                case ErreurCodeEnum.TeacherInCourse:
                    _messageToReturn = "L'utilisateur doit d'abord être retiré des cours qu'il enseigne avant de pouvoir être supprimé ou modifié";
                    break;
                default:
                        _messageToReturn = "Erreur non reconnue";
                    break;
                }
                return _messageToReturn;
            }
        }
}