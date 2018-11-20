var addVideo = new Vue({
    el: "#addVideo",
    data: {
        Prefix: "",
        Serial: "",
        WholeSerial: "",
        ActressName: "",
        Tags: "",
        MagnetLink: "",
        TorrentLink: "",
        PictureLink: "",
        CompanyName: "",
    },
    methods: {
        submit: function (event) {
            // `event` 是原生 DOM 事件
            if (event) {
                postData();
            }
        }
    }
});

function postData() {
    let formData = JSON.stringify(addVideo.$data);
    addVideo.$data.Prefix = addVideo.$data.WholeSerial.split('-')[0];
    addVideo.$data.Serial = addVideo.$data.WholeSerial.split('-')[1];
    axios.post('api/Video', {
            //formData
            Prefix: addVideo.$data.Prefix,
            Serial: addVideo.$data.Serial,
            WholeSerial: addVideo.$data.WholeSerial,
            ActressName: addVideo.$data.ActressName,
            Tags: "长腿,高颜值",
            MagnetLink: "",
            TorrentLink: "",
            PictureLink: "",
            CompanyName: ""

        })
        .then(function (response) {
            //alert("then" + response);
        })
        .catch(function (error) {
            //alert("error" + error);
        });
}