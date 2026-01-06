(function() {
    document.body.setAttribute('data-core-theme', 'light');
})();

window.toggleTheme = () => {
    const body = document.body;
    const currentTheme = body.getAttribute('data-core-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    body.setAttribute('data-core-theme', newTheme);
};
