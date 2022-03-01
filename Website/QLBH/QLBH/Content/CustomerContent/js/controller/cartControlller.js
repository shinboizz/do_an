var cart={
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnPayment').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/Cart/Payment";
        })
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('#Quantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({              
                    Quantity: $(item).val(),
                    Product: {
                        MaSP:$(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                success: function (res) {
                    if(res.status==true)
                    {
                        window.location.href = "/Cart/Index";
                    }

                }
            })
        });
        $('#btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data:{id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index";
                    }
                }
            })
        })
    }
}
cart.init();