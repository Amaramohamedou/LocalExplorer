new Swiper('.swiper-container', {
    effect: 'cards',
    grabCursor: true,
    cardsEffect: {
        rotate: true,
        perSlideRotate: 2,
        perSlideOffset: 8,
    },
    pagination: {
        el: '.swiper-pagination',
    },
});
