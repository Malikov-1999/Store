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

    // Обновляем смещение, чтобы уменьшать его по мере прокрутки
    const offset = 176 - (176 * scrollProgress); // Полная длина круга 176
    circle.style.strokeDashoffset = offset;
});

document.querySelector('.btn-scroll-top').addEventListener('click', function () {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});


document.getElementById('filterForm').addEventListener('submit', function () {
    // Показываем спиннер
    document.getElementById('loadingSpinner').style.display = 'inline-block';

    // Отключаем кнопку "Применить фильтры" чтобы избежать повторных нажатий
    document.querySelector('button[type="submit"]').disabled = true;
});

document.getElementById('filterForm').addEventListener('submit', function () {
    // Открываем модальное окно
    var loadingModal = new bootstrap.Modal(document.getElementById('loadingModal'));
    loadingModal.show();
});

document.getElementById('filterForm').addEventListener('submit', function (event) {
    // Предотвращаем стандартное поведение формы
    event.preventDefault();

    // Открываем модальное окно
    var loadingModal = new bootstrap.Modal(document.getElementById('loadingModal'));
    loadingModal.show();

    // Удерживаем модальное окно на экране на 2 секунды
    setTimeout(function () {
        loadingModal.hide();
        // Отправляем форму после того, как модальное окно скрывается
        event.target.submit();
    }, 1500); // 2000 миллисекунд = 2 секунды
});





document.querySelector('button[type="reset"]').addEventListener('click', function (event) {
    event.preventDefault(); // Останавливаем стандартное действие кнопки сброса

    // Сбрасываем поля формы
    document.getElementById('filterForm').reset();

    // Дополнительно сбрасываем поля, если необходимо
    document.getElementById('minPrice').value = '';
    document.getElementById('maxPrice').value = '';
    document.getElementById('categoryId').selectedIndex = 0;
    document.getElementById('countryOfOrigin').selectedIndex = 0;
    document.getElementById('productType').selectedIndex = 0;
    document.getElementById('surface').selectedIndex = 0;
    document.getElementById('material').selectedIndex = 0;
});
