let nav = document.getElementById('navigation');
let navItems = document.querySelectorAll(".navigation__item");

function toggleMenu() {
    nav.classList.toggle('navigation--visible');
}

if (window.innerWidth < 992) {
    navItems.forEach(item => {
        item.addEventListener("click", () => {
            nav.classList.toggle('navigation--visible');
        })
    })
}