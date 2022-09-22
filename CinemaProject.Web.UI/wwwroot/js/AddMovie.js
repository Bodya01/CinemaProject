$("#AddCategorySelect").click(function () {
    $("#CategorySelects").append('<select id="SubcategorySelect" asp-for="SubcategoryId" asp-items="ViewBag.Subcategories"></select>')
});

$("#AddSubcategorySelect").click(function () {
    $("#SubcategorySelects").append('<select id="SubcategorySelect" asp-for="SubcategoryId" asp-items="ViewBag.Subcategories"></select>')
});