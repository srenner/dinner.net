var changeQuantity = function (id, amount) {
    $.post("/Ingredient/ChangeQuantity/" + id,
        { amount: amount },
        function (data) {
            var container = document.getElementById("quantity-item-" + id);
            var oldQuantity = parseInt(container.innerHTML, 10);
            var newQuantity = data;
            if (newQuantity !== oldQuantity) {
                container.innerHTML = newQuantity;
                $(container).animate({ backgroundColor: "#00FF00" }, 750);
                $(container).animate({ backgroundColor: "#FFFFFF" }, 1250);
            }
        });
};
