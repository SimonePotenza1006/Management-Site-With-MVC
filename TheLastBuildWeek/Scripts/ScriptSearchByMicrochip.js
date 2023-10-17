function GetByChipCode(code) {
    $.ajax
        ({
            url: "Home/GetByChipCode",
            type: 'POST',
            success: function (item) {
                $('#result').append("<div> <div> <img src=~/Content/images/" + item.Foto + " width='100px' height='100px'/> </div> </div>")
            }
        })
}


$('#SearchButton').click(function () {
    let code = $("#codeInput").val()
    GetByChipCode(code)
}