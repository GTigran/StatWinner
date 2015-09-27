using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using StatWinner.Notification.BLL.Mongo.DbEntities;
using StatWinner.NotificationEngine.BLL.Common.EventManagement.Entities;

namespace StatWinner.Notification.BLL.Mongo.Factory
{
    public static class EventManagementFactory
    {
        public static Func<EventCategoryDBEntity, EventCategory> ConvertToEventCategory =
            delegate(EventCategoryDBEntity entity)
            {
                AutoMapper.Mapper.CreateMap<EventCategoryDBEntity, EventCategory>().
                    ForMember(a => a.Id, b => b.MapFrom(src => src.Id.ToString()));
                return AutoMapper.Mapper.Map<EventCategory>(entity);
            };

        public static Func<EventCategory, EventCategoryDBEntity> ConvertToEventCategoryEntity =
            delegate(EventCategory category)
            {
                AutoMapper.Mapper.CreateMap<EventCategory, EventCategoryDBEntity>()
                    .ForMember(a => a.Id, b => b.MapFrom(src => src.Id == null ? ObjectId.Empty : new ObjectId(src.Id)));
                return AutoMapper.Mapper.Map<EventCategoryDBEntity>(category);
            };

        public static Func<EventDbEntity, EventEntity> ConvertToEvent = delegate(EventDbEntity entity)
        {
            AutoMapper.Mapper.CreateMap<EventDbEntity, EventEntity>()
                .ForMember(a => a.Id, b => b.MapFrom(src => src.Id == null ? String.Empty: src.Id.ToString()));
            AutoMapper.Mapper.CreateMap<EventDbEntity, EventEntity>()
                .ForMember(a => a.CreatedBy, b => b.MapFrom(src => src.CreatedBy == null ? null : ConvertToEventUserEntity(src.CreatedBy)));
            AutoMapper.Mapper.CreateMap<EventDbEntity, EventEntity>()
                .ForMember(a => a.ModifiedBy, b => b.MapFrom(src => src.ModifiedBy == null ? null : ConvertToEventUserEntity(src.ModifiedBy)));

            return AutoMapper.Mapper.Map<EventEntity>(entity);
        };

        public static Func<EventUserDbEntity, EventUserEntity>  ConvertToEventUserEntity =
            delegate(EventUserDbEntity entity)
            {
                AutoMapper.Mapper.CreateMap<EventUserDbEntity, EventUserEntity>();
                return AutoMapper.Mapper.Map<EventUserEntity>(entity);
            };

        public static Func<EventUserEntity, EventUserDbEntity> ConvertToEventUserDbEntity =
            delegate(EventUserEntity entity)
            {
                AutoMapper.Mapper.CreateMap<EventUserEntity, EventUserDbEntity>();
                return AutoMapper.Mapper.Map<EventUserDbEntity>(entity);
            };

        public static Func<EventEntity, EventDbEntity> ConvertToEventDbEntity = delegate(EventEntity entity)
        {
            AutoMapper.Mapper.CreateMap<EventEntity, EventDbEntity>()
                .ForMember(a => a.Id, b => b.MapFrom(src => src.Id == null ? ObjectId.Empty : new ObjectId(src.Id)));
            AutoMapper.Mapper.CreateMap<EventEntity, EventDbEntity>()
                .ForMember(a => a.CreatedBy, b => b.MapFrom(src => src.CreatedBy == null ? null : ConvertToEventUserDbEntity(src.CreatedBy)));
            AutoMapper.Mapper.CreateMap<EventEntity, EventDbEntity>()
                .ForMember(a => a.ModifiedBy, b => b.MapFrom(src => src.ModifiedBy == null ? null : ConvertToEventUserDbEntity(src.ModifiedBy)));

            return AutoMapper.Mapper.Map<EventDbEntity>(entity);
        };
    }
}
