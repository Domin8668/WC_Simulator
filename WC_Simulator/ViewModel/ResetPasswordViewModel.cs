using System;
using System.Windows;
using System.Windows.Input;
using WC_Simulator.DAL.Entities;
using WC_Simulator.Helpers.Hashing;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class ResetPasswordViewModel : BaseViewModel
    {
        #region Variables

        private string _username;
        private string _newPassword;
        private string _repeatNewPassword;
        private string _selectedSecurityQuestion;
        private string _securityAnswer;

        private double _usernameBorder;
        private double _newPasswordBorder;
        private double _repeatNewPasswordBorder;
        private double _securityQuestionsBorder;
        private double _securityAnswerBorder;

        private string _usernameWarning;
        private string _newPasswordWarning;
        private string _repeatNewPasswordWarning;
        private string _securityQuestionsWarning;
        private string _securityAnswerWarning;

        #endregion


        #region Constructor

        public ResetPasswordViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            _usernameWarning = "Login musi mieć min. 5 znaków";
            _newPasswordWarning = "Hasło musi mieć min. 8 znaków";
            _repeatNewPasswordWarning = "Hasło musi mieć min. 8 znaków";
            _securityAnswerWarning = "Odpowiedź musi mieć min. 8 znaków";
        }

        #endregion


        #region Properties

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                if (_username == string.Empty)
                {
                    UsernameBorder = 0.7;
                    UsernameWarning = "Login nie może być pusty";
                }
                else
                {
                    UsernameBorder = 0;
                    UsernameWarning = string.Empty;
                }
                OnPropertyChanged(Username);
            }
        }

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                if (_newPassword == string.Empty)
                {
                    NewPasswordBorder = 0.7;
                    NewPasswordWarning = "Hasło nie może być puste";
                }
                else
                {
                    NewPasswordBorder = 0;
                    NewPasswordWarning = string.Empty;
                }
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public string RepeatNewPassword
        {
            get { return _repeatNewPassword; }
            set
            {
                _repeatNewPassword = value;
                if (_repeatNewPassword == string.Empty)
                {
                    RepeatNewPasswordBorder = 0.7;
                    RepeatNewPasswordWarning = "Hasło nie może być puste";
                }
                else
                {
                    RepeatNewPasswordBorder = 0;
                    RepeatNewPasswordWarning = string.Empty;
                }
                OnPropertyChanged(nameof(RepeatNewPassword));
            }
        }

        public string SelectedSecurityQuestion
        {
            get { return _selectedSecurityQuestion; }
            set
            {
                _selectedSecurityQuestion = value;
                if (_selectedSecurityQuestion != null)
                {
                    SecurityQuestionsBorder = 0;
                    SecurityQuestionsWarning = string.Empty;
                }
                OnPropertyChanged(nameof(SelectedSecurityQuestion));
            }
        }

        public string SecurityAnswer
        {
            get { return _securityAnswer; }
            set
            {
                _securityAnswer = value;
                if (_securityAnswer == string.Empty)
                {
                    SecurityAnswerBorder = 0.7;
                    SecurityAnswerWarning = "Odpowiedź nie może być pusta";
                }
                else
                {
                    SecurityAnswerBorder = 0;
                    SecurityAnswerWarning = string.Empty;
                }
                OnPropertyChanged(nameof(SecurityAnswer));
            }
        }

        public double UsernameBorder
        {
            get { return _usernameBorder; }
            set
            {
                _usernameBorder = value;
                OnPropertyChanged(nameof(UsernameBorder));
            }
        }

        public double NewPasswordBorder
        {
            get { return _newPasswordBorder; }
            set
            {
                _newPasswordBorder = value;
                OnPropertyChanged(nameof(NewPasswordBorder));
            }
        }

        public double RepeatNewPasswordBorder
        {
            get { return _repeatNewPasswordBorder; }
            set
            {
                _repeatNewPasswordBorder = value;
                OnPropertyChanged(nameof(RepeatNewPasswordBorder));
            }
        }

        public double SecurityQuestionsBorder
        {
            get { return _securityQuestionsBorder; }
            set
            {
                _securityQuestionsBorder = value;
                OnPropertyChanged(nameof(SecurityQuestionsBorder));
            }
        }

        public double SecurityAnswerBorder
        {
            get { return _securityAnswerBorder; }
            set
            {
                _securityAnswerBorder = value;
                OnPropertyChanged(nameof(SecurityAnswerBorder));
            }
        }

        public string UsernameWarning
        {
            get { return _usernameWarning; }
            set
            {
                _usernameWarning = value;
                OnPropertyChanged(nameof(UsernameWarning));
            }
        }

        public string NewPasswordWarning
        {
            get { return _newPasswordWarning; }
            set
            {
                _newPasswordWarning = value;
                OnPropertyChanged(nameof(NewPasswordWarning));
            }
        }

        public string RepeatNewPasswordWarning
        {
            get { return _repeatNewPasswordWarning; }
            set
            {
                _repeatNewPasswordWarning = value;
                OnPropertyChanged(nameof(RepeatNewPasswordWarning));
            }
        }

        public string SecurityQuestionsWarning
        {
            get { return _securityQuestionsWarning; }
            set
            {
                _securityQuestionsWarning = value;
                OnPropertyChanged(nameof(SecurityQuestionsWarning));
            }
        }

        public string SecurityAnswerWarning
        {
            get { return _securityAnswerWarning; }
            set
            {
                _securityAnswerWarning = value;
                OnPropertyChanged(nameof(SecurityAnswerWarning));
            }
        }

        #endregion


        #region Commands

        private ICommand _resetPassword = null;

        public ICommand ResetPassword
        {
            get
            {
                if (_resetPassword == null)
                {
                    _resetPassword = new RelayCommand(arg =>
                    {
                        SHA256Hashing myHash = new SHA256Hashing();

                        if (Username == null)
                        {
                            Username = string.Empty;
                            if (NewPassword == null)
                            {
                                NewPassword = string.Empty;
                            }
                            else
                                NewPassword = null;
                            if (RepeatNewPassword == null)
                            {
                                RepeatNewPassword = string.Empty;
                            }
                            else
                                RepeatNewPassword = null;
                            if (SelectedSecurityQuestion == null)
                            {
                                SecurityQuestionsBorder = 0.7;
                                SecurityQuestionsWarning = "Musisz wybrać pytanie";
                            }
                            else
                                SelectedSecurityQuestion = null;
                            if (SecurityAnswer == null)
                            {
                                SecurityAnswer = string.Empty;
                            }
                            else
                                SecurityAnswer = null;
                            return;
                        }
                        if (NewPassword == null)
                        {
                            NewPassword = string.Empty;
                            if (Username == null)
                            {
                                Username = string.Empty;
                            }
                            else
                                Username = null;
                            if (RepeatNewPassword == null)
                            {
                                RepeatNewPassword = string.Empty;
                            }
                            else
                                RepeatNewPassword = null;
                            if (SelectedSecurityQuestion == null)
                            {
                                SecurityQuestionsBorder = 0.7;
                                SecurityQuestionsWarning = "Musisz wybrać pytanie";
                            }
                            else
                                SelectedSecurityQuestion = null;
                            if (SecurityAnswer == null)
                            {
                                SecurityAnswer = string.Empty;
                            }
                            else
                                SecurityAnswer = null;
                            return;
                        }
                        if (RepeatNewPassword == null)
                        {
                            RepeatNewPassword = string.Empty;
                            if (Username == null)
                            {
                                Username = string.Empty;
                            }
                            else
                                Username = null;
                            if (NewPassword == null)
                            {
                                NewPassword = string.Empty;
                            }
                            else
                                NewPassword = null;
                            if (SelectedSecurityQuestion == null)
                            {
                                SecurityQuestionsBorder = 0.7;
                                SecurityQuestionsWarning = "Musisz wybrać pytanie";
                            }
                            else
                                SelectedSecurityQuestion = null;
                            if (SecurityAnswer == null)
                            {
                                SecurityAnswer = string.Empty;
                            }
                            else
                                SecurityAnswer = null;
                            return;
                        }
                        if (SelectedSecurityQuestion == null)
                        {
                            SecurityQuestionsBorder = 0.7;
                            SecurityQuestionsWarning = "Musisz wybrać pytanie";
                            if (Username == null)
                            {
                                Username = string.Empty;
                            }
                            else
                                Username = null;
                            if (NewPassword == null)
                            {
                                NewPassword = string.Empty;
                            }
                            else
                                NewPassword = null;
                            if (RepeatNewPassword == null)
                            {
                                RepeatNewPassword = string.Empty;
                            }
                            else
                                RepeatNewPassword = null;
                            if (SecurityAnswer == null)
                            {
                                SecurityAnswer = string.Empty;
                            }
                            else
                                SecurityAnswer = null;
                            return;
                        }
                        if (SecurityAnswer == null)
                        {
                            SecurityAnswer = string.Empty;
                            if (Username == null)
                            {
                                Username = string.Empty;
                            }
                            else
                                Username = null;
                            if (NewPassword == null)
                            {
                                NewPassword = string.Empty;
                            }
                            else
                                NewPassword = null;
                            if (RepeatNewPassword == null)
                            {
                                RepeatNewPassword = string.Empty;
                            }
                            else
                                RepeatNewPassword = null;
                            if (SelectedSecurityQuestion == null)
                            {
                                SecurityQuestionsBorder = 0.7;
                                SecurityQuestionsWarning = "Musisz wybrać pytanie";
                            }
                            else
                                SelectedSecurityQuestion = null;
                        }
                        if (Username.Length < 5)
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            UsernameBorder = 0.7;
                            UsernameWarning = "Login musi mieć min. 5 znaków";
                            return;
                        }
                        if (NewPassword.Length < 5)
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            NewPasswordBorder = 0.7;
                            NewPasswordWarning = "Hasło musi mieć min. 5 znaków";
                            return;
                        }
                        if (SecurityAnswer.Length < 5)
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            SecurityAnswerBorder = 0.7;
                            SecurityAnswerWarning = "Odpowiedź musi mieć min. 5 znaków";
                            return;
                        }
                        byte[] NewSecurePassword = myHash.GetHash(Username, NewPassword);
                        byte[] RepeatNewSecurePassword = myHash.GetHash(Username, RepeatNewPassword);
                        byte[] SecureSecurityAnswer = myHash.GetHash(SelectedSecurityQuestion, SecurityAnswer);
                        if (!myHash.MatchHashes(NewSecurePassword, RepeatNewSecurePassword))
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            NewPasswordBorder = RepeatNewPasswordBorder = 0.7;
                            NewPasswordWarning = RepeatNewPasswordWarning = "Hasła muszą się zgadzać";
                            return;
                        }
                        Model.CurrentUserShort.Login = Username;
                        if (!Model.CheckLogin())
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            UsernameBorder = 0.7;
                            UsernameWarning = "Nieprawidłowy login";
                            Model.CurrentUserShort.Login = null;
                            return;
                        }
                        if (!Model.ValidateAnswer(Username, SecureSecurityAnswer))
                        {
                            Username = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            SelectedSecurityQuestion = null;
                            SecurityAnswer = null;
                            SecurityAnswerBorder = 0.7;
                            SecurityAnswerWarning = "Nieprawidłowa odpowiedź";
                            return;
                        }
                        Model.CurrentUserShort.Password = NewSecurePassword;
                        Model.UpdateCurrentUserShortPassword();
                        Model.CurrentUserShort = new UserShort();
                        Model.CurrentUser = new User();

                        LoginViewModel login = new LoginViewModel(Model, NavigationStore);
                        NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, login, Visibility.Hidden, "Hasło zostało zresetowane.");
                    },
                    arg => true);
                }
                return _resetPassword;
            }
        }

        private ICommand _return = null;

        public ICommand Return
        {
            get
            {
                if (_return == null)
                {
                    _return = new RelayCommand(arg =>
                    {
                        NavigationStore.CurrentViewModel = new LoginViewModel(Model, NavigationStore);
                    },
                    arg => true);
                }
                return _return;
            }
        }


        // barebone ICommand to copy:
        //private ICommand _login = null;


        //public ICommand Login
        //{
        //    get
        //    {
        //        if (_login == null)
        //        {
        //            _login = new RelayCommand(arg => {

        //            },
        //            arg => true);
        //        }
        //        return _login;
        //    }
        //}

        #endregion
    }
}