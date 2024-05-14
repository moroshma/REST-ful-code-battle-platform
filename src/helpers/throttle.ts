/* eslint-disable prefer-rest-params */
export function throttle(func: any, ms: any): any {

    let isThrottled = false,
        savedArgs: any,
        savedThis: any;

    function wrapper(this: any) {

        if (isThrottled) { // (2)
            savedArgs = arguments;
            savedThis = this;
            return;
        }

        func.apply(this, arguments); // (1)

        isThrottled = true;

        setTimeout(function () {
            isThrottled = false; // (3)
            if (savedArgs) {
                wrapper.apply(savedThis, savedArgs);
                savedArgs = savedThis = null;
            }
        }, ms);
    }

    return wrapper;
}