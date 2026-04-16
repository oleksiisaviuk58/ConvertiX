document.getElementById('convertForm').addEventListener('reset', function () {
    setTimeout(() => {
        this.querySelectorAll('.error').forEach(el => el.classList.remove('error'));
        this.querySelectorAll('.field-error').forEach(el => el.remove());
    });
});