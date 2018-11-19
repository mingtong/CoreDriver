axios.post('api/Video', {
    Prefix: 'SW',
    Serial: '444',
    WholeSerial: "SW-444",
    ActressName: "铃木心春",
    Tags: "长腿,高颜值",
    MagnetLink: "",
    TorrentLink: "",
    PictureLink: "",
    CompanyName: ""

})
    .then(function (response) {
        console.log(response);
    })
    .catch(function (error) {
        console.log(error);
    });