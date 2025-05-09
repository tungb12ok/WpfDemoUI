namespace WpfDemoUI.ViewModels
{
    public class ButtonComponentsViewModel : ViewModelBase
    {
        public string GeneratedXaml { get; }

        public ButtonComponentsViewModel()
        {
            GeneratedXaml =
                @"<Button Content=""Primary"" Style=""{StaticResource PrimaryButtonStyle}"" />
                <Button Content=""Secondary"" Style=""{StaticResource SecondaryButtonStyle}"" />
                <Button Content=""Danger"" Style=""{StaticResource DangerButtonStyle}"" />
                <Button Content=""Outline"" Style=""{StaticResource OutlinedButtonStyle}"" />";
        }
    }
}
