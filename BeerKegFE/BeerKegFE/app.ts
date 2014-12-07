/// <reference path="..\..\..\Code Snippets\TypeScript\jquery.d.ts" />

class Greeter {
    element: HTMLElement;
    span: HTMLElement;
    timerToken: number;

    constructor(element: HTMLElement) {
        this.element = element;
        this.element.innerHTML += "The time is: ";
        this.span = document.createElement('span');
        this.element.appendChild(this.span);
        this.span.innerText = new Date().toUTCString();
    }

    start() {
        this.timerToken = setInterval(() => this.span.innerHTML = new Date().toUTCString(), 500);
    }

    stop() {
        clearTimeout(this.timerToken);
    }

}

module BeerBuzz
{
	export class BuzzAjax
	{
        submitBuzz()
        {
            var beerBuzzClip = document.getElementById("beerBuzzClip");
            alert(beerBuzzClip);
            if (beerBuzzClip != null) {
                jQuery.ajax("submitBeerBuzzClip",{
                    type: 'POST',
                    url: 'BeerBuds.com:1234',
                    data: beerBuzzClip,
                    success: function (msg)
                    { alert('success') },
                    error: function (err)
                    { alert(err.responseText) }
                });
            }
        }
	}
}

window.onload = () => {
    var el = document.getElementById('greeter');
    var greeter = new Greeter(el);
    greeter.start();
};