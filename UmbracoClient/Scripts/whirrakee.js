var backgroundCount = 1;
var loopBackgrounds = numberOfBackgrounds > 1;

var variantCount = 0;
var loopVariants = numberOfvariants > 0;

$(document).ready(function () {

    if (numberOfBackgrounds > 0) {
        $(".lazy").lazyload();
    }
});

(function loopsiloop() {
    setTimeout(function () {
        if (loopBackgrounds || loopVariants) {
            if (loopBackgrounds) {
                if (numberOfBackgrounds <= backgroundCount) {
                    backgroundCount = 1;
                    SwapBackground(backgroundCount, numberOfBackgrounds);
                }
                else {
                    SwapBackground(backgroundCount + 1, backgroundCount);
                    backgroundCount++;
                }
            }

            if (loopVariants) {
                $("#body_" + variantCount).fadeOut(2000, function () {
                    variantCount++;
                    $("#body_" + variantCount).fadeIn(2000);
                });

                if (variantCount + 1 >= window.numberOfvariants) {
                    variantCount = 0;
                }

                loopsiloop();
            }
        }
    }, 30000);
})();

function SwapBackground(to) {
    var background = $(".lazy[data-count=" + to + "]");
    $(background).fadeIn(2000);

    $(".lazy:not(.lazy[data-count=" + to + "])").fadeOut(2000);
}

$(".nav-image").hover(
    function () {
        $(this).find(".appearing-image").fadeIn('slow');
    },
    function () {
        $(this).find(".appearing-image").fadeOut('slow');
    }
);