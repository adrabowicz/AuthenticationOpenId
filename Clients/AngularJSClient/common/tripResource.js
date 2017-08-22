(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("tripResource",
                ["$resource",
                 "appSettings",
                    tripResource])

    function tripResource($resource, appSettings) {
        var url = appSettings.tripGalleryAPI + "/api/trips/:tripId";
        return $resource(url, null,
            {
                'patch':
                    {
                        method: 'PATCH',
                        transformRequest: createJsonPatchDocument
                    }
            });
    };

    var createJsonPatchDocument = function (data) {

        // create a JsonPatchDocument for the resource - the only
        // thing that can be updated in this specific case is the
        // isPublic boolean. 

        var dataToSend = "[{op: 'replace', path: '/isPublic', value: '" + !data["isPublic"] + "'}]";
        return dataToSend;
    }

}());

