function ShowConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmationModal')).show();
}

function HideConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmationModal')).hide();
}