using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Services.Password;
using PasswordManager.BusinessLogic.Models;
using System.Windows.Input;
using Spooksoft.VisualStateManager.Commands;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class StartViewModel : BaseScreenViewModel
    {
        private List<Account>? accountsList;
        private string? generatedPassword;

        private IJsonService jsonService;
        private IGeneratorService generatorService;

        private ICommand changeToAddViewCommand;
        private ICommand generatorCommand;

        private void updateAccounts()
        {
            Accounts = jsonService.LoadFromFile("accounts.json");
        }

        public StartViewModel(IChangeScreenHandler handler, IJsonService jsonService, IGeneratorService generatorService): base(handler)
        {
            this.jsonService = jsonService;
            this.generatorService = generatorService;

            GeneratorCommand = new AppCommand(obj => GeneratedPassword = generatorService.Generate());
            ChangeToAddViewCommand = new AppCommand(obj => handler.ChangeScreenToAddEditView());

            updateAccounts();
        }

        public List<Account>? Accounts
        {
            get => accountsList;
            set => Set(ref accountsList, value);
        }
        public string? GeneratedPassword
        {
            get => generatedPassword;
            set => Set(ref generatedPassword, value);
        }

        public ICommand ChangeToAddViewCommand
        {
            get => changeToAddViewCommand;
            set => Set(ref changeToAddViewCommand, value);
        }

        public ICommand GeneratorCommand
        {
            get => generatorCommand;    
            set => Set(ref generatorCommand, value);
        }
    }
}
