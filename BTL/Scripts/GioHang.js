var GioHang = {
    init: function () {
        GioHang.regEvents();
    },
    regEvents: function () {
        $('#TiepTucMuaHang').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#CapNhapGioHang').off('click').on('click', function () {
            var listSP = $('.txtSoLuong');
            var listSPNew = [];
            $.each(listSP, function (i, item) {
                listSPNew.push({
                    SoLuong: $(item).val(),
                    SP: {
                        MaSP: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/GioHang/CapNhap',
                data: { GioHangdata: JSON.stringify(listSPNew) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true)
                        window.location.href = "/GioHang";
                }
            })
        });

        $('.Xoa1SP').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { MaSP: $(this).data('id') },
                url: '/GioHang/Xoa',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang";
                    }
                }
            })
        });
        $('#XoaToanBo').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/GioHang/XoaToanBo',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/GioHang";
                    }
                }
            })
        });
    }
}

GioHang.init();