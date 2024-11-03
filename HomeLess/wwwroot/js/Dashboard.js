// Get the sidebar and main content elements
const sidebar = document.querySelector(".sidebar");
const mainContent = document.querySelector(".main-content");

// Add event listener to the toggle button
document.getElementById("menu-toggle").addEventListener("click", function () {
    sidebar.classList.toggle("collapsed");
    mainContent.classList.toggle("sidebar-collapsed");
});
