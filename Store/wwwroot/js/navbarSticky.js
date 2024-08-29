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

    // ��������� ��������, ����� ��������� ��� �� ���� ���������
    const offset = 176 - (176 * scrollProgress); // ������ ����� ����� 176
    circle.style.strokeDashoffset = offset;
});

document.querySelector('.btn-scroll-top').addEventListener('click', function () {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});


document.getElementById('filterForm').addEventListener('submit', function () {
    // ���������� �������
    document.getElementById('loadingSpinner').style.display = 'inline-block';

    // ��������� ������ "��������� �������" ����� �������� ��������� �������
    document.querySelector('button[type="submit"]').disabled = true;
});

document.getElementById('filterForm').addEventListener('submit', function () {
    // ��������� ��������� ����
    var loadingModal = new bootstrap.Modal(document.getElementById('loadingModal'));
    loadingModal.show();
});

document.getElementById('filterForm').addEventListener('submit', function (event) {
    // ������������� ����������� ��������� �����
    event.preventDefault();

    // ��������� ��������� ����
    var loadingModal = new bootstrap.Modal(document.getElementById('loadingModal'));
    loadingModal.show();

    // ���������� ��������� ���� �� ������ �� 2 �������
    setTimeout(function () {
        loadingModal.hide();
        // ���������� ����� ����� ����, ��� ��������� ���� ����������
        event.target.submit();
    }, 1500); // 2000 ����������� = 2 �������
});





document.querySelector('button[type="reset"]').addEventListener('click', function (event) {
    event.preventDefault(); // ������������� ����������� �������� ������ ������

    // ���������� ���� �����
    document.getElementById('filterForm').reset();

    // ������������� ���������� ����, ���� ����������
    document.getElementById('minPrice').value = '';
    document.getElementById('maxPrice').value = '';
    document.getElementById('categoryId').selectedIndex = 0;
    document.getElementById('countryOfOrigin').selectedIndex = 0;
    document.getElementById('productType').selectedIndex = 0;
    document.getElementById('surface').selectedIndex = 0;
    document.getElementById('material').selectedIndex = 0;
});
