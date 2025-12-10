if (!NHSNumber.TryParse(txtNhsNumber.Text, out var nhs))
{
    ShowError("Please enter a valid NHS number");
    return;
}

SearchPds(nhs.Value);