﻿function someerm(data) {
    const splitData = data.split("<!--SCRIPT GENERATED BY SERVER! PLEASE REMOVE-->");
    return splitData[0];
}

class inputSlider {
    constructor(irange , container, ivalue, unit, unitLoc) {
        // unitLoc or unit location 1 front, 2 end
        var myRange = irange;
        var myValue = ivalue;
        var myContainer = container
        var myUnits = unit;
        var off = myRange.offsetWidth / (parseInt(myRange.max) - parseInt(myRange.min));
        var px = ((myRange.valueAsNumber - parseInt(myRange.min)) * off) - (myContainer.offsetParent.offsetWidth / 2);

        myContainer.parentElement.style.left = px + 'px';
        myContainer.parentElement.style.top = myRange.offsetHeight + 'px';
        if (unitLoc == 1) myValue.innerHTML = myUnits + ' ' + myRange.value;
        else myValue.innerHTML = myRange.value + ' ' + myUnits;

        myRange.oninput = function () {
            let px = ((myRange.valueAsNumber - parseInt(myRange.min)) * off) - (myContainer.offsetWidth / 2);
            if (unitLoc == 1) myValue.innerHTML = myUnits + ' ' + myRange.value;
            else myValue.innerHTML = myRange.value + ' ' + myUnits;
            myContainer.parentElement.style.left = px + 'px';
        };
        myRange.onchange = function () {
            let px = ((myRange.valueAsNumber - parseInt(myRange.min)) * off) - (myContainer.offsetWidth / 2);
            if (unitLoc == 1) myValue.innerHTML = myUnits + ' ' + myRange.value;
            else myValue.innerHTML = myRange.value + ' ' + myUnits;
            myContainer.parentElement.style.left = px + 'px';
        };
    }
}

