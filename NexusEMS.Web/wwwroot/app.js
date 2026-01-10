(function() {
    document.body.setAttribute('data-core-theme', 'light');
})();

window.toggleTheme = () => {
    const body = document.body;
    const currentTheme = body.getAttribute('data-core-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    body.setAttribute('data-core-theme', newTheme);
    
    const syncfusionThemeLink = document.getElementById('syncfusion-theme');
    if (syncfusionThemeLink) {
        if (newTheme === 'dark') {
            syncfusionThemeLink.href = '_content/Syncfusion.Blazor.Themes/bootstrap5-dark.css';
        } else {
            syncfusionThemeLink.href = '_content/Syncfusion.Blazor.Themes/bootstrap5.css';
        }
    }
};
