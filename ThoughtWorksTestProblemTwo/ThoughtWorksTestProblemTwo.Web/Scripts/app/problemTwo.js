appRoot.controller('ProblemTwoController', function ($scope, $location, $resource) {

    var TalkResource = $resource('/api/talks', {}, { update: { method: 'PUT' } });
    $scope.sessionsIniList = [];
    $scope.talksList = [];
    $scope.tracksList = [];
    $scope.sessionsList = [];
    $scope.talksFinalList = [];

    $scope.selectedIniSessions = [];
    $scope.selectedTalks = [];
    $scope.selectedTracks = [];
    $scope.selectedSessions = [];

    $scope.$watchCollection('selectedIniSessions', function () {
        $scope.selectedIniSession = angular.copy($scope.selectedIniSessions[0]);
    });

    $scope.$watchCollection('selectedTalks', function () {
        $scope.selectedTalk = angular.copy($scope.selectedTalks[0]);
    });

    $scope.$watchCollection('selectedTracks', function () {
        $scope.selectedTrack = angular.copy($scope.selectedTracks[0]);

        if ($scope.selectedTrack != undefined && $scope.selectedTrack.Sessions != undefined)
            $scope.sessionsList = $scope.selectedTrack.Sessions;
        else
            $scope.TrackGrid.visible = false;
    });

    $scope.$watchCollection('selectedSessions', function () {
        $scope.selectedSession = angular.copy($scope.selectedSessions[0]);

        if ($scope.selectedSession != undefined && $scope.selectedSession.Talks != undefined)
            $scope.talksFinalList = $scope.selectedSession.Talks;
    });

    $scope.SessionsIniGrid = {
        showFilter: true,
        showColumnMenu: true,
        data: 'sessionsIniList',
        multiSelect: false,
        selectedItems: $scope.selectedIniSessions,
        enableColumnResize: true,
        columnDefs: [
            { field: 'Id', displayName: 'Session', width: '33%' },
            { field: 'TimeSessionMinutes', displayName: 'Time (min.)', width: '33%' },
            { field: 'TimeIniSession', displayName: 'Start Time', width: '33%' }
        ]
    };

    $scope.TalkGrid = {
        showFilter: true,
        showColumnMenu: true,
        data: 'talksList',
        multiSelect: false,
        selectedItems: $scope.selectedTalks,
        enableColumnResize: false,
        columnDefs: [
            { field: 'title', displayName: 'Title', width: '50%' },
            { field: 'timeMinutes', displayName: 'Time (min.)', width: '50%' }
        ]
    };

    $scope.TrackGrid = {
        showFilter: true,
        showColumnMenu: true,
        data: 'tracksList',
        multiSelect: false,
        selectedItems: $scope.selectedTracks,
        enableColumnResize: false,
        columnDefs: [
            { field: 'IdTrack', displayName: 'Track', width: '33%' },
            { field: 'NumberTrack', displayName: 'Number', width: '33%' },
            { field: 'TimeMinutesTotal', displayName: 'Total Minutes', width: '33%' }
        ]
    };

    $scope.SessionGrid = {
        showFilter: true,
        showColumnMenu: true,
        data: 'sessionsList',
        multiSelect: false,
        selectedItems: $scope.selectedSessions,
        enableColumnResize: true,
        columnDefs: [
            { field: 'Id', displayName: 'Session', width: '50%' },
            { field: 'TimeSessionMinutes', displayName: 'Time (min.)', width: '50%' }
        ]
    };

    $scope.TalkFinalGrid = {
        data: 'talksFinalList',
        multiSelect: false,
        enableColumnResize: true,
        columnDefs: [
           { field: 'Title', displayName: 'Title', width: '33%' },
           { field: 'TimeMinutes', displayName: 'Time (min.)', width: '33%' },
           { field: 'RealTime', displayName: 'Real Time', width: '33%' }
        ]
    };

    $scope.updateTalk = function (talk) {
        $scope.selectedTalks[0].title = talk.title;
        $scope.selectedTalks[0].timeMinutes = talk.timeMinutes;
    };

    $scope.updateIniSession = function (session) {
        $scope.selectedIniSessions[0].Id = session.Id;
        $scope.selectedIniSessions[0].TimeSessionMinutes = session.TimeSessionMinutes;
        $scope.selectedIniSessions[0].TimeIniSession = session.TimeIniSession;
    };

    $scope.insertTalk = function () {
        $scope.talksList.push({});
    };

    $scope.insertSession = function () {
        $scope.sessionsIniList.push({});
    };

    $scope.removeTalk = function () {
        angular.forEach($scope.selectedTalks, function (talk) {
            $scope.talksList = $scope.talksList.filter($scope.talksList, function (element) { return element.title != talk.title; });
        });
        $scope.selectedTalks.splice(0, $scope.selectedTalks.length);
    };

    $scope.fileUpload = function ($fileContent) {
        $scope.fileContent = $fileContent;
    };

    $scope.postTalks = function (talks, sessions) {

        var file = $scope.fileContent;
        var tracks = [];

        if (file == undefined) {
            for (var i = 0; i < parseInt($('#tracksNumber').val()) ; i++) {
                tracks[i] = {};
                tracks[i].numberTrack = i;
                tracks[i].idTrack = 'Track' + i;
                tracks[i].sessions = [];
                tracks[i].sessions = sessions;
            }
        }
        else {
            var fileParsed = JSON.parse(file);
            talks = fileParsed.talks;
            tracks = fileParsed.tracks;
        }

        var jData = {};
        jData.talks = JSON.stringify(talks);
        jData.tracks = JSON.stringify(tracks);

        var urlGet = 'http://localhost/ToughtWorksTestProblemTwo.Service/ProblemTwoService.svc/DefineTracks?talks=' + jData.talks + '&tracks=' + jData.tracks;

        $.ajax({
            url: urlGet,
            dataType: 'jsonp',
            type: 'GET',
            success: function (data) {
                $scope.tracksList = [];
                $scope.tracksList = JSON.parse(data)

                $scope.selectedTrack = angular.copy($scope.selectedTracks[0]);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(thrownError);
            }
        });
    };

    var init = function () {

    }

    init();
});