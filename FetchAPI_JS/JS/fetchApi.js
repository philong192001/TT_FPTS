$(function () {
    let list_brand;
    let list_category;

    GetAllBrand();
    GetAllCategories();
    //let options = GetAllOptions();

    function GetAllBrand() {
        $.ajax({
            url: 'https://localhost:44393/api/Brand/GetAllBrand',
            contentType: 'application/json',
            success: function (res) {
                list_brand = res;
                const options = GetAllOptions();
                //$('#brands').append(options);
            }
        });
    }

    function GetAllCategories() {
        $.ajax({
            url: 'https://localhost:44393/api/Category/GetAllCategory',
            contentType: 'application/json',
            success: function (res) {
                list_category = res;
                const options = GetAllOptions();
                //$('#categories').append(options);
            }
        });
    }

    function GetAllOptions(isProduct = true) {
        let options;
        if (isProduct) {
            list_brand.forEach(function (brand) {
                options += "<option value='" + brand.id + "'>" + brand.name + "</option>";
            });
        } else {
            list_category.forEach(function (category) {
                options += "<option value='" + category.id + "'>" + category.name + "</option>";
            });
        }
        return options;
    }

    function HandleSelectedOptions(lstOptions, selectedValue) {
        if (lstOptions && lstOptions.length > 0) {
            for (var i = 0; i < lstOptions.length; i++) {
                if (lstOptions[i].value == selectedValue) {
                    lstOptions[i].setAttribute("selected", "selected");
                    break;
                }
            }
        }
    }

    function GetValueIdBrand() {
        $(".table").on("change", "tbody tr td .brand_select", function () {
            var valuebrand = $(this).val();
            $(this).next().val(valuebrand);
            console.log(valuebrand)
        });
    }

    function GetValueIdCategory() {
        $(".table").on("change", "tbody tr td .category_select", function () {
            var valueCate = $(this).val();
            $(this).next().val(valueCate);
            console.log(valueCate)
        })
    }

    //$(document).ready(function () {
    //    $("select#brands").change(function () {
    //        var selectedBrand = $(this).children("option:selected").val();
    //        console.log(selectedBrand)
    //    })

    //});
//GET
$(document).ready(function () {
    $('#get-button').on('click', function () {

        var select = document.createElement('select');
        var select_cate = document.createElement('select');
        var selectEl = "<select>";

        //var options = '';
        var optionsCate = GetAllOptions(false);
        let optionsBrand = GetAllOptions();

        $.ajax({
            url: 'https://localhost:44393/api/Product/GetProductJoin',
            contentType: 'application/json',
            success: function (rs) {
                //console.log(rs)
                var tbodyEl = $('tbody');
                tbodyEl.html('');

                rs.forEach(function (product) {

                    // For Select of brand
                    select.innerHTML = optionsBrand;
                    select.className = "brand_select";
                    $('select').attr("id", "brandSelect");
                    HandleSelectedOptions(select.options, product.id_brands);

                    // For Select of category
                    select_cate.innerHTML = optionsCate;
                    select_cate.className = "category_select";
                    HandleSelectedOptions(select_cate.options, product.id_categories);

                    tbodyEl.append('\
                                    <tr>\
                                        <td class="id">'+ product.id + '</td>\
                                        <td><input type="text" class="name" value="'+ product.name + '" /></td>\
                                        <td>\
                                        <input type="text" class="price" value="'+ product.price + '"></td>\
                                        <td><input type="text" class="quantity" value="'+ product.quantity + '"></td>\
                                        <td>'+ select_cate.outerHTML + '' + '<input type="hidden" id="valueCate"  value="' + product.id_categories + '">' + '</td>\
                                        <td> '+ select.outerHTML + ' ' + '<input type="hidden" id="valueBrand" value="' + product.id_brands + '">' + ' </td>\
                                        <td><input type="text" class="created_at" value="'+ product.created_Date + '"></td>\
                                        <td>\
                                        <button class="btn btn-success update-button"> UPDATE</button>\
                                        <button class="btn btn-warning delete-button">DELETE</button>\
                                        </td >\
                                    </tr >\
                                    ');
                    GetValueIdBrand();
                    GetValueIdCategory();
                });
            }
        })
    });


})
})

//CREATE
$('#submit').on('click', function (e) {
    e.preventDefault();
    var nameInput = $('#inputName').val();
    var priceInput = $('#inputPrice').val();
    var quantityInput = $('#inputQuantity').val();
    var idCateInput = $('#categories').val();
    console.log(idCateInput);
    var idBrandInput = $('#brands').val();
    console.log(idBrandInput) 
    var DateInput = $('#input_created_date').val();
    console.log(DateInput)
    //console.log(hiddenInput);
    //tìm hidden input mà có id = productId và lấy value của nó (lúc này value của hiddend input = value mới vừa selected)

    let abc = {
        name: nameInput,
        price: parseInt(priceInput),
        quantity: parseInt(quantityInput),
        id_categories: parseInt(idCateInput),
        id_brands: parseInt(idBrandInput),
        created_Date: DateInput
    }
    $.ajax({
        url: 'https://localhost:44393/api/Product/Create',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(
            abc
        ),
        success: function (rs) {
            $('#get-button').click()
            //console.log(rs)
            swal({
                title: "Good job!",
                text: "You clicked the button!",
                icon: "success",
                button: "Aww yiss!",
            });
        }
    });
});

//UPDATE
$('table').on('click', '.update-button', function () {
    let rowEl = $(this).closest('tr');
    let id = rowEl.find('.id').text();

    let newName = rowEl.find('.name').val();
    let newPrice = rowEl.find('.price').val();
    let newQuantity = rowEl.find('.quantity').val();
    let newDate = rowEl.find('.created_at').val();
    let hiddenInputBrand = rowEl.find('#valueBrand').val();
    let hiddenInputCate = rowEl.find('#valueCate').val();

    console.log(hiddenInputBrand);
    console.log(hiddenInputCate)


    $.ajax({
        url: 'https://localhost:44393/api/Product/Update',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            id: parseInt(id),
            name: newName,
            price: parseInt(newPrice),
            quantity: parseInt(newQuantity),
            id_categories: parseInt(hiddenInputCate),
            id_brands: parseInt(hiddenInputBrand),
            created_Date: newDate
        }),
        success: function (response) {
            console.log(response);
            $('#get-button').click()
            swal("Your update success!");
        }
    });
});

//DELETE
$('table').on('click', '.delete-button', function () {
    let rowEl = $(this).closest('tr');
    let id = rowEl.find('.id').text();
    //console.log(id)
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this imaginary file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: 'https://localhost:44393/api/Product/Delete/' + id,
                    method: 'POST',
                    contentType: 'application/json',
                    success: function (rs) {
                        console.log(rs);
                        $('#get-button').click()
                    }
                });
                swal("Poof! Your imaginary file has been deleted!", {
                    icon: "success",
                });
            } else {
                swal("Your imaginary file is safe!");
            }
        });
});


