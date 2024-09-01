window.addEventListener('scroll', function () {
    var navbar = document.getElementById('navbar');
    if (window.scrollY > 0) {
        navbar.classList.remove('rounded-pill');
        navbar.classList.add('rounded-bottom-only');
    } else {
        navbar.classList.remove('rounded-bottom-only');
        navbar.classList.add('rounded-pill');
    }
});



window.addEventListener('scroll', function () {
    const circle = document.querySelector('.progress-circle circle');
    const totalHeight = document.documentElement.scrollHeight - window.innerHeight;
    const scrollPosition = window.scrollY;
    const scrollProgress = scrollPosition / totalHeight;

    const offset = 176 - (176 * scrollProgress); 
    circle.style.strokeDashoffset = offset;
});

document.querySelector('.btn-scroll-top').addEventListener('click', function () {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});

