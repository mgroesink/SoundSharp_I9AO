using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SoundSharp_I9AO.Models
{
    public partial class SoundSharpContext : DbContext
    {
        public SoundSharpContext()
        {
        }

        public SoundSharpContext(DbContextOptions<SoundSharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audiodevice> Audiodevices { get; set; }
        public virtual DbSet<Cddiscman> Cddiscmen { get; set; }
        public virtual DbSet<Memorecorder> Memorecorders { get; set; }
        public virtual DbSet<Mp3player> Mp3players { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Relation2> Relation2s { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SoundSharp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Audiodevice>(entity =>
            {
                entity.ToTable("AUDIODEVICE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Btw)
                    .HasColumnType("numeric(3, 1)")
                    .HasColumnName("btw");

                entity.Property(e => e.Make)
                    .HasMaxLength(50)
                    .HasColumnName("make");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("model");

                entity.Property(e => e.OwnerId).HasColumnName("OWNER_id");

                entity.Property(e => e.PriceExBtw)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("price_ex_btw");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Audiodevices)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AUDIODEVICE_OWNER_FK");
            });

            modelBuilder.Entity<Cddiscman>(entity =>
            {
                entity.ToTable("CDDISCMAN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Displayheight).HasColumnName("displayheight");

                entity.Property(e => e.Displaywidth).HasColumnName("displaywidth");

                entity.Property(e => e.IsEjected).HasColumnName("is_ejected");

                entity.Property(e => e.Mbsize).HasColumnName("mbsize");

                entity.HasOne(d => d.AudioDevice)
                    .WithOne(p => p.Cddiscman)
                    .HasForeignKey<Cddiscman>(d => d.Id)
                    .HasConstraintName("CDDISCMAN_AUDIODEVICE_FK");
            });

            modelBuilder.Entity<Memorecorder>(entity =>
            {
                entity.ToTable("MEMORECORDER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MaxCartridgeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("max_cartridge_type");

                entity.HasOne(d => d.AudioDevice)
                    .WithOne(p => p.Memorecorder)
                    .HasForeignKey<Memorecorder>(d => d.Id)
                    .HasConstraintName("MEMORECORDER_AUDIODEVICE_FK");
            });

            modelBuilder.Entity<Mp3player>(entity =>
            {
                entity.HasKey(e => e.Serialid)
                    .HasName("MP3PLAYER_PK");

                entity.ToTable("MP3PLAYER");

                entity.Property(e => e.Serialid)
                    .ValueGeneratedNever()
                    .HasColumnName("serialid");

                entity.Property(e => e.Displayheight).HasColumnName("displayheight");

                entity.Property(e => e.Displaywidth).HasColumnName("displaywidth");

                entity.Property(e => e.Mbsize).HasColumnName("mbsize");

                entity.HasOne(d => d.AudioDevice)
                    .WithOne(p => p.Mp3player)
                    .HasForeignKey<Mp3player>(d => d.Serialid)
                    .HasConstraintName("MP3PLAYER_AUDIODEVICE_FK");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("OWNER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Housenumber).HasColumnName("housenumber");

                entity.Property(e => e.HousenumberAdd)
                    .HasMaxLength(10)
                    .HasColumnName("housenumber_add");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(25)
                    .HasColumnName("middlename");

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("postalcode")
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .HasMaxLength(50)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.ToTable("PLAYLIST");

                entity.Property(e => e.PlaylistId)
                    .HasColumnType("numeric(28, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLAYLIST_ID");

                entity.Property(e => e.Mp3playerSerialid).HasColumnName("MP3PLAYER_serialid");

                entity.HasOne(d => d.Mp3playerSerial)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.Mp3playerSerialid)
                    .HasConstraintName("PLAYLIST_MP3PLAYER_FK");
            });

            modelBuilder.Entity<Relation2>(entity =>
            {
                entity.HasKey(e => new { e.TrackId, e.PlaylistPlaylistId })
                    .HasName("Relation_2_PK");

                entity.ToTable("Relation_2");

                entity.Property(e => e.TrackId).HasColumnName("TRACK_id");

                entity.Property(e => e.PlaylistPlaylistId)
                    .HasColumnType("numeric(28, 0)")
                    .HasColumnName("PLAYLIST_PLAYLIST_ID");

                entity.HasOne(d => d.PlaylistPlaylist)
                    .WithMany(p => p.Relation2s)
                    .HasForeignKey(d => d.PlaylistPlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relation_2_PLAYLIST_FK");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Relation2s)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relation_2_TRACK_FK");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("TRACK");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Albumsource)
                    .HasMaxLength(100)
                    .HasColumnName("albumsource");

                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("artist");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Style)
                    .HasMaxLength(1)
                    .HasColumnName("style");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
