var swiper = new Swiper(".mySwiper", {
    slidesPerView: 1,
    breakpoints: {
        640: {
            slidesPerView: 2,
            spaceBetween: 10,
        },
        768: {
            slidesPerView: 3,
            spaceBetween: 20,
        },
        1024: {
            slidesPerView: 4,
            spaceBetween: 25,
        }
    },
    spaceBetween: 20,
    autoplay: {
        delay: 2500,
        disableOnInteraction: true
    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
});