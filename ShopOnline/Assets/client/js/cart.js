var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('.remove').off('click').on('click', function () {
            $.ajax({
                data:{id:$(this).data('id')},
                url:'/Cart/Delete',
            dataType:'json',
            type:'POST',
            success: function(res){
                if(res.status== true){
                    window.location.href="/Cart";
                }
            }
            })
        })
    }
}
cart.init();