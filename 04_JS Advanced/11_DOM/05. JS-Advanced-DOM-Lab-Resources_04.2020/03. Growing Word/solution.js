function growingWord() {

    const title = document.querySelector('.conditions');
    const colors = document.querySelectorAll('.color');

    console.log(colors);


    const pixels = [];
    for (i = 1; i <= 20; i++) {
        pixels[i - 1] = i;
    }

    //функция за random елемент от масива (самия елемент не индекса)
    function random_item(items) {
        return items[Math.floor(Math.random() * items.length)];
    }

    console.log(random_item(pixels));
    console.log(random_item(colors));

    let pix = random_item(pixels);
    let color = random_item(colors);

    let currentColor = color.innerHTML;
    console.log(currentColor);

    title.style.color = currentColor;
    title.style.fontSize = `${pix}px`;
}