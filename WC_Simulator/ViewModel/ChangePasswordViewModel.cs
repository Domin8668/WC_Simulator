using System.Windows;
using System.Windows.Input;
using WC_Simulator.Helpers.Hashing;
using WC_Simulator.Helpers.Stores;
using WC_Simulator.Model;
using WC_Simulator.ViewModel.BaseClasses;

namespace WC_Simulator.ViewModel
{
    internal class ChangePasswordViewModel : BaseViewModel
    {
        #region Variables

        private string _oldPassword;
        private string _newPassword;
        private string _repeatNewPassword;

        private double _oldPasswordBorder;
        private double _newPasswordBorder;
        private double _repeatNewPasswordBorder;

        private string _oldPasswordWarning;
        private string _newPasswordWarning;
        private string _repeatNewPasswordWarning;

        #endregion


        #region Constructor

        public ChangePasswordViewModel(MainModel model, NavigationStore navigationStore)
        {
            Model = model;
            NavigationStore = navigationStore;
            _newPasswordWarning = "Hasło musi mieć min. 8 znaków";
            _repeatNewPasswordWarning = "Hasło musi mieć min. 8 znaków";
        }

        #endregion


        #region Properties

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                if (_oldPassword == string.Empty)
                {
                    OldPasswordBorder = 0.7;
                    OldPasswordWarning = "Hasło nie może być puste";
                }
                else
                {
                    OldPasswordBorder = 0;
                    OldPasswordWarning = string.Empty;
                }
                OnPropertyChanged(OldPassword);
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

        public double OldPasswordBorder
        {
            get { return _oldPasswordBorder; }
            set
            {
                _oldPasswordBorder = value;
                OnPropertyChanged(nameof(OldPasswordBorder));
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

        public string OldPasswordWarning
        {
            get { return _oldPasswordWarning; }
            set
            {
                _oldPasswordWarning = value;
                OnPropertyChanged(nameof(OldPasswordWarning));
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

        #endregion


        #region Commands

        private ICommand _changePassword = null;

        public ICommand ChangePassword
        {
            get
            {
                if (_changePassword == null)
                {
                    _changePassword = new RelayCommand(arg =>
                    {
                        SHA256Hashing myHash = new SHA256Hashing();

                        if (OldPassword == null)
                        {
                            OldPassword = string.Empty;
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
                            return;
                        }
                        if (NewPassword == null)
                        {
                            NewPassword = string.Empty;
                            if (OldPassword == null)
                            {
                                OldPassword = string.Empty;
                            }
                            else
                                OldPassword = null;
                            if (RepeatNewPassword == null)
                            {
                                RepeatNewPassword = string.Empty;
                            }
                            else
                                RepeatNewPassword = null;
                            return;
                        }
                        if (RepeatNewPassword == null)
                        {
                            RepeatNewPassword = string.Empty;
                            if (OldPassword == null)
                            {
                                OldPassword = string.Empty;
                            }
                            else
                                OldPassword = null;
                            if (NewPassword == null)
                            {
                                NewPassword = string.Empty;
                            }
                            else
                                NewPassword = null;
                            return;
                        }
                        if (OldPassword.Length < 8)
                        {
                            OldPassword = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            OldPasswordBorder = 0.7;
                            OldPasswordWarning = "Hasło musi mieć min. 8 znaków";
                            return;
                        }
                        if (NewPassword.Length < 8)
                        {
                            OldPassword = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            NewPasswordBorder = 0.7;
                            NewPasswordWarning = "Hasło musi mieć min. 8 znaków";
                            return;
                        }
                        byte[] OldSecurePassword = myHash.GetHash(Model.CurrentUserShort.Login, OldPassword);
                        byte[] NewSecurePassword = myHash.GetHash(Model.CurrentUserShort.Login, NewPassword);
                        byte[] RepeatNewSecurePassword = myHash.GetHash(Model.CurrentUserShort.Login, RepeatNewPassword);
                        if (!myHash.MatchHashes(NewSecurePassword, RepeatNewSecurePassword))
                        {
                            OldPassword = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            NewPasswordBorder = RepeatNewPasswordBorder = 0.7;
                            NewPasswordWarning = RepeatNewPasswordWarning = "Hasła muszą się zgadzać";
                            return;
                        }

                        (OldSecurePassword, Model.CurrentUserShort.Password) = (Model.CurrentUserShort.Password, OldSecurePassword);
                        if (!Model.ValidateUserShort())
                        {
                            (OldSecurePassword, Model.CurrentUserShort.Password) = (Model.CurrentUserShort.Password, OldSecurePassword);
                            OldPassword = null;
                            NewPassword = null;
                            RepeatNewPassword = null;
                            OldPasswordBorder = 0.7;
                            OldPasswordWarning = "Nieprawidłowe hasło";
                            return;
                        }
                        (NewSecurePassword, Model.CurrentUserShort.Password) = (Model.CurrentUserShort.Password, NewSecurePassword);
                        Model.UpdateCurrentUserPassword();

                        ProfileViewModel profile = new ProfileViewModel(Model, NavigationStore);
                        NavigationStore.CurrentViewModel = new MessageViewModel(Model, NavigationStore, profile, Visibility.Visible, "Hasło zostało zmienione.");
                    },
                    arg => true);
                }
                return _changePassword;
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
                        NavigationStore.CurrentViewModel = new ProfileViewModel(Model, NavigationStore);
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
