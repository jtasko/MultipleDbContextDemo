$(function () {
    var l = abp.localization.getResource("MultipleDbContextDemo");
	
    var testMySqlEntityService = window.multipleDbContextDemo.mySql.testMySqlEntities.testMySqlEntities;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "TestMySqlEntities/CreateModal",
        scriptUrl: "/Pages/TestMySqlEntities/createModal.js",
        modalClass: "testMySqlEntityCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "TestMySqlEntities/EditModal",
        scriptUrl: "/Pages/TestMySqlEntities/editModal.js",
        modalClass: "testMySqlEntityEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val()
        };
    };

    var dataTable = $("#TestMySqlEntitiesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(testMySqlEntityService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('MultipleDbContextDemo.TestMySqlEntities.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('MultipleDbContextDemo.TestMySqlEntities.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    testMySqlEntityService.delete(data.record.id)
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

    $("#NewTestMySqlEntityButton").click(function (e) {
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
