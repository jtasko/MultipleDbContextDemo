$(function () {
    var l = abp.localization.getResource("MultipleDbContextDemo");
	
    var testSqlServerEntityService = window.multipleDbContextDemo.testSqlServerEntities.testSqlServerEntities;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "TestSqlServerEntities/CreateModal",
        scriptUrl: "/Pages/TestSqlServerEntities/createModal.js",
        modalClass: "testSqlServerEntityCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "TestSqlServerEntities/EditModal",
        scriptUrl: "/Pages/TestSqlServerEntities/editModal.js",
        modalClass: "testSqlServerEntityEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val()
        };
    };

    var dataTable = $("#TestSqlServerEntitiesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(testSqlServerEntityService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('MultipleDbContextDemo.TestSqlServerEntities.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('MultipleDbContextDemo.TestSqlServerEntities.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    testSqlServerEntityService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewTestSqlServerEntityButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});
