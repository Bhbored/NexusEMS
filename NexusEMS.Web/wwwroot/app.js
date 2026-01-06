(function() {
    const savedTheme = localStorage.getItem('theme') || 'light';
    document.body.setAttribute('data-core-theme', savedTheme);
})();

window.toggleTheme = () => {
    const body = document.body;
    const currentTheme = body.getAttribute('data-core-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    body.setAttribute('data-core-theme', newTheme);
    localStorage.setItem('theme', newTheme);
};

window.getTheme = () => {
    return document.body.getAttribute('data-core-theme') || 'light';
};
