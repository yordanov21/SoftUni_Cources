function toggle() {
    let btn = document.getElementsByTagName('span')[0];

    if (document.getElementById('extra').style.display === 'none') {
        document.getElementById('extra').style.display = 'block';
        btn.textContent = 'Less'
    } else {
        document.getElementById('extra').style.display = 'none';
        btn.textContent = 'More';
    }
}