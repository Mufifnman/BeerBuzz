/// <reference path="..\..\..\Code Snippets\TypeScript\jquery.d.ts" />
var Greeter = (function () {
    function Greeter(element) {
        this.element = element;
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        this.span.innerText = new Date().toUTCString();
    }
    Greeter.prototype.start = function () {
        var _this = this;
        this.timerToken = setInterval(function () { return _this.span.innerHTML = new Date().toUTCString(); }, 500);
    };
    Greeter.prototype.stop = function () {
        clearTimeout(this.timerToken);
    };
    return Greeter;
})();
var BeerBuzz;
(function (BeerBuzz) {
    var BuzzAjax = (function () {
        function BuzzAjax() {
        }
        BuzzAjax.prototype.submitBuzz = function () {
            var beerBuzzClip = document.getElementById("beerBuzzClip");
            alert(beerBuzzClip);
            if (beerBuzzClip != null) {
                jQuery.ajax("submitBeerBuzzClip", {
                    type: 'POST',
                    url: 'BeerBuds.com:1234',
                    data: beerBuzzClip,
                    success: function (msg) {
                        alert('success');
                    },
                    error: function (err) {
                        alert(err.responseText);
                    }
                });
            }
        };
        return BuzzAjax;
    })();
    BeerBuzz.BuzzAjax = BuzzAjax;
})(BeerBuzz || (BeerBuzz = {}));
window.onload = function () {
    var el = document.getElementById('greeter');
    var greeter = new Greeter(el);
    greeter.start();
};
//# sourceMappingURL=app.js.map