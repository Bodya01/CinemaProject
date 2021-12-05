userTable = () => $("#userTable").each(function () {
    $(this).DataTable({
        processing: true,
        serverSide: true,
        searching: true,
        paging: false,
        info: false,
        columns: [
            { name: 'Email' },
            { name: 'UserName' },
            { name: 'UserSurname' },
            { name: 'UserPhone' },
            { name: 'links' }
        ],
    });
});