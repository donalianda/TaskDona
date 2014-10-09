﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicListApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AlbumDBEntities : DbContext
    {
        public AlbumDBEntities()
            : base("name=AlbumDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MST_ARTIST> MST_ARTIST { get; set; }
        public DbSet<MST_GENRE> MST_GENRE { get; set; }
        public DbSet<TRANSACT_ALBUM> TRANSACT_ALBUM { get; set; }
        public DbSet<TBL_LOGIN> TBL_LOGIN { get; set; }
    
        public virtual ObjectResult<SP_ALBUM_Result> SP_ALBUM()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ALBUM_Result>("SP_ALBUM");
        }
    
        public virtual ObjectResult<SP_ALBUM_BY_TITLE_Result> SP_ALBUM_BY_TITLE(string title)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ALBUM_BY_TITLE_Result>("SP_ALBUM_BY_TITLE", titleParameter);
        }
    }
}