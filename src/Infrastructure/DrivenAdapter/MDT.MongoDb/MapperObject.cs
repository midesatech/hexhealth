using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace MDT.MongoDb
{
    public static class MapperObject
    {
        public static IMapper mapper { get; set; } = new MapperConfiguration(cfg => { }).CreateMapper();
        public static IMapper mapperWithConstructor { get; set; } = new MapperConfiguration(cfg => { cfg.ShouldUseConstructor = ci => !ci.IsPrivate; }).CreateMapper();

    }
}