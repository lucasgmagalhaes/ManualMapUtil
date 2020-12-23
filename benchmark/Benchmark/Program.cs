using AppSample;
using AutoMapper;
using Benchmark.Entities;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Benchmark
{
    public class BenchMarkMap
    {
        public Hero HeroBase;
        public IMapper mapper;

        public BenchMarkMap()
        {
            HeroBase = new Hero
            {
                Id = 1231241,
                Player = new Player
                {
                    Id = 32123,
                    Name = "Thor Superman",
                    Email = "thorGiantDestroyer@odin.com",
                    Active = true
                },
                Name = "Captain America",
                Level = 100,
                HpActual = 1000,
                Xp = 20000,
                LevelMaxXp = 1000032,
                Gold = 1235161.52,
                CreateDate = DateTime.Now,
                Itens = new List<Item>
                {
                    new Item
                    {
                        Id = 123,
                        Name = "Mjölnir",
                        Price = 11000000,
                        Type = ItemType.WEAPON
                    },
                    new Item
                    {
                        Id = 32124,
                        Name = "Cap",
                        Price = 3335646,
                        Type = ItemType.CLOTHES
                    },
                     new Item
                    {
                        Id = 324242,
                        Name = "Cap",
                        Price = 64651,
                        Type = ItemType.CLOTHES
                    },
                     new Item
                    {
                        Id = 123,
                        Name = "Boots",
                        Price = 12312412,
                        Type = ItemType.CLOTHES
                    },
                    new Item
                    {
                        Id = 123111111,
                        Name = "Shotingun",
                        Price = 412121,
                        Type = ItemType.GUN
                    }
                }
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hero, HeroDTO>();
                cfg.CreateMap<Player, PlayerDTO>();
                cfg.CreateMap<Item, ItemDTO>();
                cfg.CreateMap<List<Item>, List<ItemDTO>>();
            });
            mapper = config.CreateMapper();

            AppSample.Mapper.InjectMap<Hero, HeroDTO>(HeroToHeroDTO);
        }

        public static HeroDTO HeroToHeroDTO(Hero player)
        {
            return new HeroDTO
            {
                Id = player.Id,
                Player = new PlayerDTO
                {
                    Id = player.Player.Id,
                    Name = player.Player.Name,
                    Email = player.Player.Email,
                    Active = player.Player.Active
                },
                Name = player.Name,
                Level = player.Level,
                HpActual = player.HpActual,
                Xp = player.Xp,
                LevelMaxXp = player.LevelMaxXp,
                Gold = player.Gold,
                CreateDate = player.CreateDate,
                Itens = player.Itens.ConvertAll(playerIten => new ItemDTO
                {
                    Id = playerIten.Id,
                    Name = playerIten.Name,
                    Price = playerIten.Price,
                    Type = playerIten.Type
                })
            };
        }

        [Benchmark]
        public HeroDTO ManualMap() => AppSample.Mapper.Map<Hero, HeroDTO>(HeroBase);

        [Benchmark]
        public HeroDTO AutoMapperMap() => mapper.Map<HeroDTO>(HeroBase);

        [Benchmark]
        public HeroDTO ManualMapCall() => HeroToHeroDTO(HeroBase);
    }

    class Program
    {
        static void Main(string[] args)
        {
           var summary = BenchmarkRunner.Run<BenchMarkMap>();
        }

    }
}
